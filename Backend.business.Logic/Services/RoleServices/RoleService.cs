using Backend.business.DataAccess.Data;
using Backend.business.DataAccess.Models;
using Backend.business.Logic.ModelsImage;


namespace Backend.business.Logic.Services.RoleServices
{
    public class RoleService
    {
        private presenceManagementDbContext? ManagementPresenceDbContext;
        public RoleService(presenceManagementDbContext dataDbContext)
        {
            ManagementPresenceDbContext = dataDbContext;
        }



        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            List<Role> roles = ManagementPresenceDbContext.Roles.Select(ro => new Role()
            {
                RoleId = ro.RoleId,
                RoleName = ro.RoleName
            }
            ).ToList();
            return await Task.FromResult(roles);
        }

        public async Task<Role?> GetRoleByIdAsync(int id)
        {
            return await Task.FromResult(ManagementPresenceDbContext.Roles.Where(r => r.RoleId == id).FirstOrDefault());
        }


        public async Task<Role> CreateRoleAsync(RolesImage RolesImages)
        {
            Role role = new Role();

            if (RolesImages != null)
            {
                role.RoleName = RolesImages.RoleName;
                ManagementPresenceDbContext.Add(role);
                await ManagementPresenceDbContext.SaveChangesAsync();
                return role;
            }

            return role;
        }
        public async Task<Role> UpdateRoleAsync(RolesImage RolesImages)
        {
            Role role = new Role();

            if (RolesImages != null)
            {
                role.RoleId = RolesImages.RoleId;
                role.RoleName = RolesImages.RoleName;
                ManagementPresenceDbContext.Update(role);
                await ManagementPresenceDbContext.SaveChangesAsync();
                return role;
            }

            return role;
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var role = await GetRoleByIdAsync(id);
            if (role == null)
                return false;
            ManagementPresenceDbContext.Remove(role);
            await ManagementPresenceDbContext.SaveChangesAsync();
            return true;
        }

    }

}
