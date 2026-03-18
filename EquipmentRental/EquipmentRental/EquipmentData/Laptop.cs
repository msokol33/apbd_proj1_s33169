namespace EquipmentRental.EquipmentData;

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
        int batteryLife,
        int screenDiagonal,
        string operatingSystem)
        : this(Guid.NewGuid(),status, warrantyFrom, warrantyTo, brand, model, batteryLife,
            screenDiagonal, operatingSystem)
    {
    }

    public Laptop(Guid id,
        EquipmentStatus status,
        DateTime warrantyFrom,
        DateTime warrantyTo,
        string brand,
        string model,
        int batteryLife,
        int screenDiagonal,
        string operatingSystem
        )
        : base(id, status, warrantyFrom, warrantyTo, brand, model)
    {
        BatteryLife = batteryLife;
        ScreenDiagonal = screenDiagonal;
        OperatingSystem = operatingSystem;
    }
}