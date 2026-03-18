namespace EquipmentRental.User.Data;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public int RentalCount { get; set; }
    public int Limit { get; set; }
    public User(Guid id, string name, string surname, int limit)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Limit = limit;
    }

    
}