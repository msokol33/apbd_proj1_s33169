namespace EquipmentRental.EquipmentData;

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
        int sensorSize,
        int megaPixelCount) 
        : this(Guid.NewGuid(),  status, warrantyFrom, warrantyTo, brand, model, sensorSize, megaPixelCount)
    {
    }


    public Camera(
        Guid id,
        EquipmentStatus status,
        DateTime warrantyFrom,
        DateTime warrantyTo,
        string brand,
        string model,
        int sensorSize,
        int megaPixelCount
    ) : base(id, status, warrantyFrom, warrantyTo, brand, model)
    {
        SensorSize = sensorSize;
        MegaPixelCount = megaPixelCount;
    }
}