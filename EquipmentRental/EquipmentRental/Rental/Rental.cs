using EquipmentRental.EquipmentData;
using EquipmentRental.UserData;

namespace EquipmentRental.Rental;

public class Rental
{
    public Guid Id { get; set; }
    public User User { get; set; }
    public EquipmentBase Item { get; set; }
    public DateTime RentFrom { get; set; }
    public DateTime RentTo { get; set; }
    public DateTime? ReturnDate { get; set; }
    
    public decimal? Charge { get; set; }

    public Rental(Guid id, User user, EquipmentBase item, DateTime rentFrom, DateTime rentTo)
    {
        Id = id;
        User = user;
        Item = item;
        RentFrom = rentFrom;
        RentTo = rentTo;
    }
}