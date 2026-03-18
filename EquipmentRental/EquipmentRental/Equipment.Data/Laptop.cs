namespace EquipmentRental.Equipment.Data;

public class Laptop(long id, EquipmentStatus status, DateTime warrantyFrom, DateTime warrantyTo, DateTime rentalFrom, DateTime rentalTo, string brand, string model, decimal rentalPrice, int batteryLife, string operatingSystem, int screenDiagonal) : EquipmentBase(id, status, warrantyFrom, warrantyTo, rentalFrom, rentalTo, brand, model, rentalPrice)
{
    public int BatteryLife {get; set;} = batteryLife;
    public int ScreenDiagonal { get; set; } = screenDiagonal;
    public string OperatingSystem {get; set;} = operatingSystem;
}