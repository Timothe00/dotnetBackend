using Backend.business.DataAccess.Models;
using Backend.business.Logic.ModelsImage;

namespace Backend.business.Logic.Services.UsersServices
{
    public interface IUsersService
    {
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users?> GetUserByIdAsync(int id);

        Task<Users> CreateUserAsync(ImagePost UsersImages);

        Task<Users> UpdateUserAsync(ImagePost UsersImages);
        Task<bool> DeleteUserAsync(int id);
    }
}
