namespace EquipmentRental.UserData;

public class Employee : User
{
    public Employee(
        string name,
        string surname
    ) : base(Guid.NewGuid(), name, surname, 5)
    {
        RentalCount = 0;
    }
}