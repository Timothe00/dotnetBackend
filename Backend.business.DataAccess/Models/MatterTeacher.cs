using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.business.DataAccess.Models
{
    public class MatterTeacher
    {
        public int MatterTeacherId {get; set;}
        public int TeacherId {get; set;}
        public int MatterId {get; set;}
        public Matters? Matters {get; set;}
        public ICollection<SessionCours>? SessionCours{get; set;}
        public Teacher? Teachers {get; set;}
    }
        
}