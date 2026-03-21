using EquipmentRental.EquipmentData;
using EquipmentRental.RentalData;
using EquipmentRental.UserData;

namespace EquipmentRental.Interfaces;

public interface IRentalService
{
    public void Rent(Guid userId, Guid equipmentId, int days);

    public void Return(Rental rental);

    public void DisplayActiveRentalForUser(Guid userId);

    public void DisplayExpiredRentals();
    
    public void DisplayRentalReport();

    public void AddExtraCharge(Rental rental, decimal amount);
}