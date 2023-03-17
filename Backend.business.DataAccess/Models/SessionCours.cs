using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.business.DataAccess.Models
{
    public class SessionCours
    {
        public int SessionCoursId { get; set; }
        public string? Semestre { get; set; }
        public string? Years { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string? HourStart { get; set; }
        public string? HourEnd { get; set; }
        public int AbsenceId { get; set; }
        public ICollection<Absence>? Absences { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public int MatterId { get; set; }
        public Matters? Matters { get; set; }
    }
}
