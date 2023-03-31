using Backend.business.DataAccess.Models;
using Backend.business.Logic.ModelsImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.business.Logic.Services.AdminServices
{
    public interface IAdminServices
    {
        Task<IEnumerable<Admin>> GetAdminsAsync();
        Task<Admin?> GetAdminIdAsync(int id);
        Task<Admin> CreateAdminAsync(AdminImage adminImages);
        Task<bool> UpdateAdminAsync(AdminImage adminImages, int id);
        Task<bool> DeleteAdminAsync(int id);
    }
}
