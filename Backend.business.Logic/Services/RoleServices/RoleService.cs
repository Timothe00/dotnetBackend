using Backend.business.DataAccess.Data;
using Backend.business.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.business.Logic.Services.RoleServices
{
    public class RoleService
    {
        private ManagementPresenceDbContext? ManagementPresenceDbContext;
        public RoleService(ManagementPresenceDbContext dataDbContext)
        {
            ManagementPresenceDbContext = dataDbContext;
        }



        public IEnumerable<Role> GetAllRoles()
        {
            return ManagementPresenceDbContext.Roles.ToList();
        }


        public Role GetRoleById(int id)
        {
            var roleById = ManagementPresenceDbContext.Roles.Where(role => role.RoleId == id).FirstOrDefault();

            if (roleById == null)
            {
                return null;
            }

            return roleById;
        }


        public Role? AddRole(Role role)
        {
            var Trole = ManagementPresenceDbContext.Add(role);
            if (Trole != null)
            {
                ManagementPresenceDbContext.SaveChanges();
                return Trole.Entity;
            }
            return null;
        }


        public Role? RoleUpdate(Role Xrole) { 
            var role = ManagementPresenceDbContext.Roles.Update(Xrole);

            if (role != null)
            {
                Role Yrole = new Role();
                Yrole.RoleId = Xrole.RoleId;
                Yrole.RoleName = Xrole.RoleName;
                ManagementPresenceDbContext.Roles.Update(Xrole);
                ManagementPresenceDbContext.SaveChanges();
                return Xrole;
            }

            return null;

        }

        public bool RoleDelete(int id)
        {
            Role Xrole = GetRoleById(id);
            if (Xrole != null)
            {
                var Xro = ManagementPresenceDbContext.Roles.Remove(Xrole);

                if (Xro != null)
                {
                    ManagementPresenceDbContext.SaveChanges();
                }

                return false;
            }
            else
            {
                throw new NotImplementedException();
            }

        }

    }
}
