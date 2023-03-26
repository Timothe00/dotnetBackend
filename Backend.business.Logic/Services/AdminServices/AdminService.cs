
using Backend.business.DataAccess.Data;
using Backend.business.DataAccess.Models;
using Backend.business.Logic.ModelsImage;

namespace Backend.business.Logic.Services.AdminServices
{
    public class AdminService
    {
         private presenceManagementDbContext ManagementPresenceDbContext;

        public AdminService (presenceManagementDbContext dataDbContext)
        {
            ManagementPresenceDbContext = dataDbContext;
        }

        public async Task<IEnumerable<Admin>> GetAdminsAsync()
        {
            List<Admin> admins = ManagementPresenceDbContext.Admins.Select(admin => new Admin()
            {
                UserId = admin.UserId,
                UsersLname = admin.UsersLname,
                UsersFname = admin.UsersFname,
                UsersGender = admin.UsersGender,
                UsersEmail = admin.UsersEmail,
                UsersPassword= admin.UsersPassword,
                RoleId = admin.RoleId,
            }).ToList();
            return await Task.FromResult(admins);
        }


        public async Task<Admin?> GetAdminIdAsync(int id)
        {
            return await Task.FromResult(ManagementPresenceDbContext.Admins.Where(r => r.UserId == id).FirstOrDefault());
        }


        public async Task<Admin> CreateAdminAsync(AdminImage adminImages)
        {

            Admin admin = new Admin();

            if (adminImages != null)
            {
                admin.UsersLname = adminImages.UsersLname;
                admin.UsersFname = adminImages.UsersFname;
                admin.UsersGender = adminImages.UsersGender;
                admin.UsersEmail = adminImages.UsersEmail;
                admin.UsersPassword = adminImages.UsersPassword;
                admin.RoleId = 1;
                ManagementPresenceDbContext.Add(admin);
                await ManagementPresenceDbContext.SaveChangesAsync();
                return admin;

            }
            return admin;
        }
        


         public async Task<bool> UpdateAdminAsync(AdminImage adminImages, int id)
        {

            Admin? admin = await GetAdminIdAsync(id);

            if (adminImages != null && admin != null)
            {
                admin.UserId = id;
                admin.UsersLname = adminImages.UsersLname;
                admin.UsersFname = adminImages.UsersFname;
                admin.UsersGender = adminImages.UsersGender;
                admin.UsersPassword = adminImages.UsersPassword;

                admin.RoleId = 1;
                ManagementPresenceDbContext.UpdateRange(admin);
                await ManagementPresenceDbContext.SaveChangesAsync();

                return true;

            }
            return false;
        }


        public async Task<bool> DeleteAdminAsync(int id)
        {
            var admin = await GetAdminIdAsync(id);
            if (admin == null)
                return false;
            ManagementPresenceDbContext.Remove(admin);
            await ManagementPresenceDbContext.SaveChangesAsync();
            return true;
        }
    }
}