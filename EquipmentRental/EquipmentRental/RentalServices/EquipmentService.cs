using EquipmentRental.EquipmentData;
using EquipmentRental.Interfaces;

namespace EquipmentRental.RentalServices;

public class EquipmentService : IEquipmentService
{
    public IList<EquipmentBase> EquipmentList { get; }= new List<EquipmentBase>();
    public void AddNewEquipment(
        EquipmentType type,
        string brand,
        string model,
        DateTime warrantyFrom,
        DateTime warrantyTo,
        params object[] args)
    {
        EquipmentBase equipment = type switch
        {
            EquipmentType.Camera => new Camera(
                EquipmentStatus.Available,
                warrantyFrom,
                warrantyTo,
                brand,
                model,
                (int)args[0],
                (int)args[1]
            ),

            EquipmentType.Laptop => new Laptop(
                EquipmentStatus.Available,
                warrantyFrom,
                warrantyTo,
                brand,
                model,
                (int)args[0], 
                (int)args[1],
                (string)args[2]
            ),

            EquipmentType.Chair => new Chair(
                EquipmentStatus.Available,
                warrantyFrom,
                warrantyTo,
                brand,
                model,
                (string)args[0],
                (string)args[1]
            ),

            EquipmentType.Projector => new Projector(
                EquipmentStatus.Available,
                warrantyFrom,
                warrantyTo,
                brand,
                model,
                (int)args[0],
                (int)args[1]
            ),

            _ => throw new ArgumentException("Nieznany typ sprzętu")
        };

        EquipmentList.Add(equipment);
        Console.WriteLine($"  Dodano sprzęt: [{type}] {brand} {model}");
    }
    
    
    public void DisplayEquipment()
    {
        Console.WriteLine(EquipmentList.Count + " equipment stored.");
        foreach (var equipment in EquipmentList)
        {
            Console.WriteLine($"Brand: {equipment.Brand}, Model:{equipment.Model}, Status:{equipment.Status}");
        }
    }

    public EquipmentBase GetEquipmentByBrandAndModel(string brand, string model)
    {
        return EquipmentList.First(x => x.Brand == brand && x.Model == model);
    }

    public void DisplayAvailableEquipment()
    {
        var availableEquipment = EquipmentList.Where(x => x.Status == EquipmentStatus.Available).ToList();
        Console.WriteLine(availableEquipment.Count + " equipment available");
        foreach (var equipment in availableEquipment)
        {
            Console.WriteLine($"Available models to rent: {equipment.Brand}, {equipment.Model}");
        }
    }
    
    public void MarkAsUnavailable(Guid equipmentId)
    {
        var equip = EquipmentList.First(x => x.Id == equipmentId);
        equip.Status = EquipmentStatus.Unavailable;
    }

    public void MarkAsNotInService(Guid equipmentId)
    {
        var equip = EquipmentList.First(x => x.Id == equipmentId);
        equip.Status = EquipmentStatus.NotInService;
    }

    public void MarkAsAvailable(Guid equipmentId)
    {
        var equip = EquipmentList.First(x => x.Id == equipmentId);
        equip.Status = EquipmentStatus.Available;
    }

    public bool IsAvailable(Guid equipmentId)
    {
        var equip = EquipmentList.First(x => x.Id == equipmentId);
        return equip.Status == EquipmentStatus.Available;
    }

    
}