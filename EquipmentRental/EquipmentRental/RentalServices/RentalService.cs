using EquipmentRental.Interfaces;
using EquipmentRental.RentalData;

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
            
        
        Rentals.Add(new Rental(Guid.NewGuid(), userId, equipmentId, DateTime.UtcNow, DateTime.UtcNow.AddDays(days), RentalStatus.Active));
        Rentals.Last().Status = RentalStatus.Active;
        _userService.ManipulateUserRentalCount(userId, false);
        _equipmentService.MarkAsUnavailable(equipmentId);

        var user = _userService.GetUserById(userId);
        Console.WriteLine($"  Wypożyczono [{equipmentId}] przez {user.Name} {user.Surname} na {days} dni  [{user.RentalCount}/{user.Limit}]");
    }

    public Rental GetRentalByEquipmentId(Guid equipmentId)
    {
        return Rentals.Last(x => x.ItemId == equipmentId);
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
        
        rentalReturn.Status =  RentalStatus.Finished;
        _userService.ManipulateUserRentalCount(rentalReturn.UserId, true);
        _equipmentService.MarkAsAvailable(rentalReturn.ItemId);

        Console.WriteLine($"  Zwrot [{rentalReturn.ItemId}]  |  opłata: {rental.Charge:F2} PLN  |  status: {rentalReturn.Status}");
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
        if (expiredRentals.Count == 0)
        {
            Console.WriteLine("No expired rentals");
            return;
        }

        Console.WriteLine($"Expired rentals: {expiredRentals.Count}");
        foreach (var rental in expiredRentals)
        {
            Console.WriteLine($"Id: {rental.Id} - Supposed to return to date: {rental.RentTo}");
        }
    }

    public void DisplayRentalReport()
    {
        var activeRentals = Rentals.Where(x => x.Status == RentalStatus.Active).ToList().Count;
        var finishedRentals = Rentals.Where(x => x.Status == RentalStatus.Finished).ToList().Count;
        var expiredRentals = Rentals.Where(IsRentalExpired).ToList().Count;
        Console.WriteLine("=============Rental-Rapport=============");
        Console.WriteLine($"\nRentals in total: {Rentals.Count}");
        Console.WriteLine($"\nActive rentals count: {activeRentals}");
        Console.WriteLine($"\nFinished rentals count: {finishedRentals}");
        Console.WriteLine($"\nExpired rentals count: {expiredRentals}");
        Console.WriteLine("\nRentals in details: ");
        foreach (var rental in Rentals)
        {
            Console.WriteLine($"\nId: {rental.Id} - Status: {rental.Status} - Return date: {rental.ReturnDate}");
        }
    }

    public void AddExtraCharge(Rental rental, decimal amount)
    {
        rental.Charge += amount;
    }

    private static bool IsRentalExpired(Rental rental)
    {
        return rental.ReturnDate is null && rental.RentTo < DateTime.UtcNow;
    }
}