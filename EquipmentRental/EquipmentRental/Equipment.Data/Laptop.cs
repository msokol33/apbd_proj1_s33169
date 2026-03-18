namespace EquipmentRental.Equipment.Data;

public class Laptop : EquipmentBase 
{
    public int BatteryLife {get; set;}
    public int ScreenDiagonal { get; set; }
    public string OperatingSystem {get; set;}

    public Laptop(EquipmentStatus status,
        DateTime warrantyFrom,
        DateTime warrantyTo,
        string brand,
        string model,
        decimal rentalPrice,
        int batteryLife,
        int screenDiagonal,
        string operatingSystem)
        : this(Guid.NewGuid(),status, warrantyFrom, warrantyTo, brand, model, rentalPrice, batteryLife,
            screenDiagonal, operatingSystem)
    {
    }

    public Laptop(Guid id,
        EquipmentStatus status,
        DateTime warrantyFrom,
        DateTime warrantyTo,
        string brand,
        string model,
        decimal rentalPrice,
        int batteryLife,
        int screenDiagonal,
        string operatingSystem
        )
        : base(id, status, warrantyFrom, warrantyTo, brand, model, rentalPrice)
    {
        BatteryLife = batteryLife;
        ScreenDiagonal = screenDiagonal;
        OperatingSystem = operatingSystem;
    }
}