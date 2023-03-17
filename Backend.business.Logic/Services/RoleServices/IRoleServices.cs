using Backend.business.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.business.Logic.Services.RoleServices
{
    public interface IRoleServices
    {
        IEnumerable<Role> GetAllRoles();
        Role GetRoleById(int id);
        Role? AddRole(Role role);
        Role? RoleUpdate(Role Xrole);
        bool RoleDelete(int id);
    }
}
