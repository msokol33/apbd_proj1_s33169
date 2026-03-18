namespace EquipmentRental.Equipment.Data;

public class Camera : EquipmentBase
{
    public int SensorSize { get; set; }
    public int MegaPixelCount { get; set; }

    public Camera(
        EquipmentStatus status,
        DateTime warrantyFrom,
        DateTime warrantyTo,
        string brand,
        string model,
        decimal rentalPrice,
        int sensorSize,
        int megaPixelCount) 
        : this(Guid.NewGuid(),  status, warrantyFrom, warrantyTo, brand, model, rentalPrice, sensorSize, megaPixelCount)
    {
    }


    public Camera(
        Guid id,
        EquipmentStatus status,
        DateTime warrantyFrom,
        DateTime warrantyTo,
        string brand,
        string model,
        decimal rentalPrice,
        int sensorSize,
        int megaPixelCount
    ) : base(id, status, warrantyFrom, warrantyTo, brand, model, rentalPrice)
    {
        SensorSize = sensorSize;
        MegaPixelCount = megaPixelCount;
    }
}