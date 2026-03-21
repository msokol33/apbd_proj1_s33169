using EquipmentRental.Interfaces;
using EquipmentRental.UserData;

namespace EquipmentRental.RentalServices;

public class UserService : IUserService
{
    public IList<User> ListOfUsers { get; } = new List<User>();
    
    public void Create(UserType type, string name, string surname)
    {
        switch (type){
            case UserType.User:
                ListOfUsers.Add(new User(Guid.NewGuid(), name, surname));
                break;
            case UserType.Employee:
                ListOfUsers.Add(new Employee(name, surname));
                break;
            case UserType.Student:
                ListOfUsers.Add(new Student(name, surname));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }

    public User GetUserById(Guid userId)
    {
        var user = ListOfUsers.First(x => x.Id == userId);
        return user;
    }

    public void ManipulateUserRentalCount(Guid userId, bool isReturn)
    {
        var user = ListOfUsers.First(x => x.Id == userId);
        if (isReturn)
            user.RentalCount -= 1;
        else
            user.RentalCount += 1;
    }
    
    public bool IsUserInLimit(Guid userId)
    {
        var user = ListOfUsers.First(x => x.Id == userId);
        return user.Limit > user.RentalCount;
    }
}