namespace EquipmentRental.EquipmentData;

public class EquipmentBase(
    Guid id,
    EquipmentStatus status,
    DateTime warrantyFrom,
    DateTime warrantyTo,
    string brand,
    string model)
{
    //id, status, gwarancja, czas wypozyczenia, marka, model, cena
    public Guid Id { get; set; } = id;
    public EquipmentStatus Status { get; set; } = status;
    public DateTime WarrantyFrom { get; set; } = warrantyFrom;
    public DateTime WarrantyTo { get; set; } = warrantyTo;
    public string Brand { get; set; } = brand;
    public string Model { get; set; } = model;
    public Dictionary<string, object> Extensions { get; set; } = new();
}