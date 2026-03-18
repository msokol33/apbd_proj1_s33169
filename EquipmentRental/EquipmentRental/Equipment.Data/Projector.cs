namespace EquipmentRental.Equipment.Data;

public class Projector(long id, EquipmentStatus status, DateTime warrantyFrom, DateTime warrantyTo, DateTime rentalFrom, DateTime rentalTo, string brand, string model, decimal rentalPrice, int throwRatio, int resolution) : EquipmentBase(id, status, warrantyFrom, warrantyTo, rentalFrom, rentalTo, brand, model, rentalPrice)
{
    public int ThrowRatio {get; set;} = throwRatio;
    public int Resolution {get; set;} = resolution;
}