using Backend.business.DataAccess.Models;
using Backend.business.Logic.ModelsImage;


namespace Backend.business.Logic.Services.RoleServices
{
    public interface IRoleServices
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role?> GetRoleByIdAsync(int id);
        Task<Role> CreateRoleAsync(RolesImage RolesImages);
        Task<Role> UpdateRoleAsync(RolesImage RolesImages);
        Task<bool> DeleteRoleAsync(int id);
    }
}
