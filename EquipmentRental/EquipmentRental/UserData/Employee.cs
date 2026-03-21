namespace EquipmentRental.UserData;

public class Employee : User
{
    public Employee(
        string name,
        string surname
    ) : base(Guid.NewGuid(), name, surname, RentalLimits.EmployeeLimit)
    {
        RentalCount = 0;
    }
}