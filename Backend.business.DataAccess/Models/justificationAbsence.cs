using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.business.DataAccess.Models
{
    public class justificationAbsence
    {
        public int JustificationId { get; set; }
        public string? JustificationEdit { get; set; }

        public int? AbsenceId { get; set; }
        public Absence? Absence { get; set; } 
        public int StudentId { get; set; }
        public Student? Students { get;set; }
    }
}
