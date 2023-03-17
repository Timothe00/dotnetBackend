

namespace Backend.business.DataAccess.Models
{
    public class Matters
    {
        public int MatterId { get; set; }
        public string? MatterName { get; set; }

        public int SessionCoursId { get; set; }
        public ICollection<SessionCours>? SessionCours { get; set; }    
    }
}
