namespace EquipmentRental.User.Data;

public class Employee : User
{
    public Employee(
        Guid id,
        string name,
        string surname
    ) : base(id, name, surname, 5)
    {
        RentalCount = 0;
    }
}