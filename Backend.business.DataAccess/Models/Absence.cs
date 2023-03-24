using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.business.DataAccess.Models
{
    public class Absence
    {
        public int AbsenceId { get; set; }
        public bool Status { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int SessionCoursId { get; set; }
        public SessionCours? SessionCours { get; set; }
        public justificationAbsence? JustificationAbsence { get; set; }
    }
}
