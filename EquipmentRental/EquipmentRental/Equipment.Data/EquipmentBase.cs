namespace EquipmentRental.Equipment.Data;

public class EquipmentBase(
    long id,
    EquipmentStatus status,
    DateTime warrantyFrom,
    DateTime warrantyTo,
    DateTime rentalFrom,
    DateTime rentalTo,
    string brand,
    string model,
    decimal rentalPrice)
{
    //id, status, gwarancja, czas wypozyczenia, marka, model, cena
    public long Id { get; set; } = id;
    public EquipmentStatus Status { get; set; } = status;
    public DateTime WarrantyFrom { get; set; } = warrantyFrom;
    public DateTime WarrantyTo { get; set; } = warrantyTo;
    public DateTime RentalFrom { get; set; } = rentalFrom;
    public DateTime RentalTo { get; set; } = rentalTo;
    public string Brand { get; set; } = brand;
    public string Model { get; set; } = model;
    public decimal RentalPrice { get; set; } = rentalPrice;
}