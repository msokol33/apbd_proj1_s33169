using EquipmentRental.RentalData;

namespace EquipmentRental.Interfaces;

public interface IRentalService
{
    public void Rent(Guid userId, Guid equipmentId, int days);

    public Rental GetRentalByEquipmentId(Guid equipmentId);

    public void Return(Rental rental);

    public void DisplayActiveRentalForUser(Guid userId);

    public void DisplayExpiredRentals();
    
    public void DisplayRentalReport();

    public void AddExtraCharge(Rental rental, decimal amount);
}