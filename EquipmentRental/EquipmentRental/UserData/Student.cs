namespace EquipmentRental.UserData;

public class Student : User
{
    public Student(
        string name,
        string surname
    ) : base(Guid.NewGuid(), name, surname, RentalLimits.StudentLimit)
    {
        RentalCount = 0;
    }
}