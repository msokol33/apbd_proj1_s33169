namespace EquipmentRental.Equipment.Data;

public class Camera(long id, EquipmentStatus status, DateTime warrantyFrom, DateTime warrantyTo, DateTime rentalFrom, DateTime rentalTo, string brand, string model, decimal rentalPrice, int megaPixelCount, int sensorSize) : EquipmentBase(id, status, warrantyFrom, warrantyTo, rentalFrom, rentalTo, brand, model, rentalPrice)
{
    public int SensorSize { get; set; } = sensorSize;
    public int MegaPixelCount { get; set; } = megaPixelCount;
}