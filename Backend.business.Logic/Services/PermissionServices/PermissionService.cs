using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.business.DataAccess.Data;
using Backend.business.DataAccess.Models;
using Backend.business.Logic.ModelsImage;

namespace Backend.business.Logic.Services.PermissionServices
{
    public class PermissionService : IPermissionServices
    {
        private presenceManagementDbContext ManagementPresenceDbContext;
        public PermissionService(presenceManagementDbContext dataDbContext)
        {
            ManagementPresenceDbContext = dataDbContext;
        }



         public async Task<IEnumerable<Permission>> GetAllPermissionAsync()
        {
            List<Permission> permissions = ManagementPresenceDbContext.Permissions.Select(pe => new Permission()
            {
                PermissionId = pe.PermissionId,
                StudentId = pe.StudentId,
                PermissionReason = pe.PermissionReason,
                PermissionStatus = pe.PermissionStatus,
                PermissionBeginAt = pe.PermissionBeginAt,
                PermissionEndAt = pe.PermissionEndAt
            }
            ).ToList();
            return await Task.FromResult(permissions);
        }


        public async Task<Permission?> GetPermissionByIdAsync(int id)
        {
            return await Task.FromResult(ManagementPresenceDbContext.Permissions.Where(p => p.PermissionId == id).FirstOrDefault());
        }


        public async Task<Permission> CreatePermissionAsync(PermissionImage PermissionImages)
        {
            Permission permission = new Permission();

            if (PermissionImages != null)
            {
                permission.PermissionId = PermissionImages.PermissionId;
                permission.StudentId = PermissionImages.StudentId;
                permission.PermissionReason = PermissionImages.PermissionReason;
                permission.PermissionBeginAt = PermissionImages.PermissionBeginAt;
                permission.PermissionEndAt = PermissionImages.PermissionEndAt;
                ManagementPresenceDbContext.Add(permission);
                await ManagementPresenceDbContext.SaveChangesAsync();
                return permission;
            }

            return permission;
        }


         public async Task<Permission> UpdatePermissionAsync(PermissionImage PermissionImages)
        {
            Permission permission = new Permission();

            if (PermissionImages != null)
            {
                permission.PermissionId = PermissionImages.PermissionId;
                permission.StudentId = PermissionImages.StudentId;
                permission.PermissionReason = PermissionImages.PermissionReason;
                permission.PermissionBeginAt = PermissionImages.PermissionBeginAt;
                permission.PermissionEndAt = PermissionImages.PermissionEndAt;
                ManagementPresenceDbContext.Update(permission);
                await ManagementPresenceDbContext.SaveChangesAsync();
                return permission;
            }

            return permission;
        }


        public async Task<bool> DeletePermissionAsync(int id)
        {
            var permission = await GetPermissionByIdAsync(id);
            if (permission == null)
            return false;
            ManagementPresenceDbContext.Remove(permission);
            await ManagementPresenceDbContext.SaveChangesAsync();
            return true;
        }
    }
}