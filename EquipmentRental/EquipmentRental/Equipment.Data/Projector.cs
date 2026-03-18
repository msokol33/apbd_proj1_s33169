namespace EquipmentRental.Equipment.Data;

public class Projector : EquipmentBase 
{
    public int ThrowRatio {get; set;}
    public int Resolution {get; set;}

    public Projector(EquipmentStatus status,
        DateTime warrantyFrom,
        DateTime warrantyTo,
        string brand,
        string model,
        decimal rentalPrice,
        int throwRatio,
        int resolution)
        : this(Guid.NewGuid(), status, warrantyFrom, warrantyTo, brand, model, rentalPrice,
            throwRatio, resolution)
    {
    }
    public Projector(
        Guid id,
        EquipmentStatus status,
        DateTime warrantyFrom,
        DateTime warrantyTo,
        string brand,
        string model,
        decimal rentalPrice,
        int throwRatio,
        int resolution)
        : base(id, status, warrantyFrom, warrantyTo, brand, model, rentalPrice)
    {
        ThrowRatio = throwRatio;
        Resolution = resolution;
    }

}