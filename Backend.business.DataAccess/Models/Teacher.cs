using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.business.DataAccess.Models
{
    [Table("Teacher")]
    public class Teacher : Users
    {
        public ICollection<MatterTeacher>? MatterTeachers { get; set; } 
    }
}
