namespace EquipmentRental.Equipment.Data;

public class Chair : EquipmentBase
{
    public string Material {get; set;}
    public string AdjustableFeatures {get; set;}

    public Chair(EquipmentStatus status,
        DateTime warrantyFrom,
        DateTime warrantyTo,
        string brand,
        string model,
        decimal rentalPrice,
        string material,
        string adjustableFeatures
    ) : this(Guid.NewGuid(), status, warrantyFrom, warrantyTo, brand, model, rentalPrice,
        material, adjustableFeatures)
    {
    }

    public Chair(
        Guid id,
        EquipmentStatus status,
        DateTime warrantyFrom,
        DateTime warrantyTo,
        string brand,
        string model,
        decimal rentalPrice,
        string material,
        string adjustableFeatures
        ):base(id, status,  warrantyFrom, warrantyTo, brand, model, rentalPrice)
    {
        Material = material;
        AdjustableFeatures = adjustableFeatures;
    }
}