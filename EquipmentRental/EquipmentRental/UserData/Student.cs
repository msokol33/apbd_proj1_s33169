namespace EquipmentRental.UserData;

public class Student : User
{
    public Student(
        Guid id,
        string name,
        string surname
    ) : base(id, name, surname, 2)
    {
        RentalCount = 0;
    }
}