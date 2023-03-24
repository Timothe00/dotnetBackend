
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.business.DataAccess.Models
{
    [Table("Student")]
    public class Student : Users
    {

        public ICollection<Absence>? Absences { get; set; }
        public ICollection<Permission>? Permissions { get; set; }
        public ICollection<justificationAbsence>? justificationAbsence  { get; set;}
    }
}
