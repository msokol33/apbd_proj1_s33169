using EquipmentRental.EquipmentData;

namespace EquipmentRental.Interfaces;

public interface IEquipmentService
{
    public void AddNewEquipment(EquipmentType type, string brand, string model, DateTime warrantyFrom, DateTime warrantyTo, params object[] args);
    public EquipmentBase GetEquipmentByBrandAndModel(string brand, string model);
    public void DisplayEquipment();
    public void DisplayAvailableEquipment();
    public void MarkAsUnavailable(Guid equipmentId);
    public void MarkAsAvailable(Guid equipmentId);
    public void MarkAsNotInService(Guid equipmentId);
    public bool IsAvailable(Guid equipmentId);
}