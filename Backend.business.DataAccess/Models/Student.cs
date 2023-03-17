
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.business.DataAccess.Models
{
    [Table("Student")]
    public class Student:Users
    {
     
        public int AbsenceId { get; set; }
        public ICollection<Absence>? Absences { get; set; }
        public int PermissionId { get; set; }
        public ICollection<Permission>? Permissions { get; set; }
    }
}
