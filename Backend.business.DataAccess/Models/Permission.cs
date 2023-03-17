using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.business.DataAccess.Models
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public string? PermissionReason { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
