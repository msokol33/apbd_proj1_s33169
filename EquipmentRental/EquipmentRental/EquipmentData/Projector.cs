namespace EquipmentRental.EquipmentData;

public class Projector : EquipmentBase 
{
    public int ThrowRatio {get; set;}
    public int Resolution {get; set;}

    public Projector(EquipmentStatus status,
        DateTime warrantyFrom,
        DateTime warrantyTo,
        string brand,
        string model,
        int throwRatio,
        int resolution)
        : this(Guid.NewGuid(), status, warrantyFrom, warrantyTo, brand, model,
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
        int throwRatio,
        int resolution)
        : base(id, status, warrantyFrom, warrantyTo, brand, model)
    {
        ThrowRatio = throwRatio;
        Resolution = resolution;
    }

}