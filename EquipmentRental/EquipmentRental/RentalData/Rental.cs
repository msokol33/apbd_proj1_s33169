using EquipmentRental.EquipmentData;
using EquipmentRental.UserData;

namespace EquipmentRental.RentalData;

public class Rental
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ItemId { get; set; }
    public DateTime RentFrom { get; set; }
    public DateTime RentTo { get; set; }
    public DateTime? ReturnDate { get; set; }
    public decimal? Charge { get; set; }
    public RentalStatus Status { get; set; }

    public Rental(Guid id, Guid userId, Guid itemId, DateTime rentFrom, DateTime rentTo, RentalStatus status)
    {
        Id = id;
        UserId = userId;
        ItemId = itemId;
        RentFrom = rentFrom;
        RentTo = rentTo;
        Status = RentalStatus.None;
    }
}