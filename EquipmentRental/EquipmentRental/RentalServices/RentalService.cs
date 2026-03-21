using EquipmentRental.EquipmentData;
using EquipmentRental.Interfaces;
using EquipmentRental.RentalData;
using EquipmentRental.UserData;

namespace EquipmentRental.RentalServices;

public class RentalService :IRentalService
{
    private const int FirstStageChargeRate = 25;
    private const int SecondStageChargeRate = 100;
    public readonly IList<Rental> Rentals = new List<Rental>();
    private IEquipmentService _equipmentService;
    private IUserService _userService;

    public RentalService(IEquipmentService equipmentService, IUserService userService)
    {
        _equipmentService = equipmentService;
        _userService = userService;
    }

    public void Rent(Guid userId, Guid equipmentId, int days)
    {
        if (!_userService.IsUserInLimit(userId))
            throw new InvalidOperationException($"User {userId} has reached the rental count.");

        if (!_equipmentService.IsAvailable(equipmentId))
            throw new InvalidOperationException($"Equipment id {equipmentId}, is not available for rental.");
            
        
        Rentals.Add(new Rental(Guid.NewGuid(), userId, equipmentId, DateTime.UtcNow, DateTime.UtcNow.AddDays(days)));
        _userService.ManipulateUserRentalCount(userId, false);
        _equipmentService.MarkAsUnavailable(equipmentId);
    }

    public void Return(Rental rental)
    {
        var rentalReturn = Rentals.FirstOrDefault(x => x.Id == rental.Id);
        if (rentalReturn == null)
        {
            throw new ArgumentNullException("Could not find rental with id: " + rental.Id);
        }

        var timeDiff = DateTime.UtcNow - rentalReturn.RentTo;
        switch (timeDiff.TotalDays)
        {
            case <= 1:
                rental.ReturnDate = DateTime.UtcNow;
                rental.Charge = 0;
                break;
            case > 1 and < 3:
                rental.ReturnDate = DateTime.UtcNow;
                rental.Charge = timeDiff.Hours * FirstStageChargeRate;
                break;
            default:
                rental.ReturnDate = DateTime.UtcNow;
                rental.Charge = timeDiff.Hours * SecondStageChargeRate;
                break;
        }
        
        _userService.ManipulateUserRentalCount(rentalReturn.UserId, true);
        _equipmentService.MarkAsAvailable(rentalReturn.Id);
    }

    public void DisplayActiveRentalForUser(Guid userId)
    {
        var activeRentals = Rentals.Where(x => x.UserId == userId).ToList();
        var user = _userService.GetUserById(userId);
        Console.WriteLine($"Active rentals for userId: {user.Id}, Name: {user.Name} {user.Surname}");
        foreach (var rental in activeRentals)
        {
            Console.WriteLine($"\t {rental.Id}, from:  {rental.RentFrom}, to: {rental.RentTo}" );
        }
    }

    public void DisplayExpiredRentals()
    {
        var expiredRentals = Rentals.Where(IsRentalExpired).ToList();
        if(expiredRentals.Count == 0)
            Console.WriteLine("No expired rentals");
        
        Console.WriteLine($"Expired rentals: {expiredRentals.Count}");
        foreach (var rental in expiredRentals)
        {
            Console.WriteLine($"Id: {rental.Id} - Return date: {rental.ReturnDate}");
        }
    }

    public void DisplayRentalReport()
    {
        
    }

    public void AddExtraCharge(Rental rental, decimal amount)
    {
        rental.Charge += amount;
    }

    private static bool IsRentalExpired(Rental rental)
    {
        return rental.ReturnDate is null && rental.ReturnDate < DateTime.UtcNow;
    }
}