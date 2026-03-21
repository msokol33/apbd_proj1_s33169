using EquipmentRental.UserData;

namespace EquipmentRental.Interfaces;

public interface IUserService
{
    public void Create(UserType type, string name, string surname);
    
    public User GetUserById(Guid userId);
    
    public void ManipulateUserRentalCount(Guid userId, bool isReturn);
    
    public bool IsUserInLimit(Guid userId);
}