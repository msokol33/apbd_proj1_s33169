namespace EquipmentRental.Equipment.Data;

public class Chair(long id, EquipmentStatus status, DateTime warrantyFrom, DateTime warrantyTo, DateTime rentalFrom, DateTime rentalTo, string brand, string model, decimal rentalPrice, string material, string adjustableFeatures) : EquipmentBase(id, status, warrantyFrom, warrantyTo, rentalFrom, rentalTo, brand, model, rentalPrice)
{
    public string Material {get; set;} = material;
    public string AdjustableFeatures {get; set;} = adjustableFeatures;
}