using Backend.business.DataAccess.Models;


namespace Backend.business.Logic.Services.UsersServices
{
    public interface IUsersService
    {
        ICollection<Users> GetAllUsers();
        Users GetUsersById(int id);
        Users AddUser(Users user);
        Users? UserUpdate(Users Xuser);
        bool UserDelete(int id);
    }
}
