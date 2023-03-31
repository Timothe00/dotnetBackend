using Backend.business.DataAccess.Models;
using Backend.business.Logic.ModelsImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
