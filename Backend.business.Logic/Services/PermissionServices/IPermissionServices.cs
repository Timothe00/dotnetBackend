using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.business.Logic.ModelsImage;
using Backend.business.DataAccess.Models;

namespace Backend.business.Logic.Services.PermissionServices
{
    public interface IPermissionServices
    {
        Task<IEnumerable<Permission>> GetAllPermissionAsync();
        Task<Permission?> GetPermissionByIdAsync(int id);
        Task<Permission> CreatePermissionAsync(PermissionImage PermissionImages);
        Task<Permission> UpdatePermissionAsync(PermissionImage PermissionImages);
        Task<bool> DeletePermissionAsync(int id);
    }
}