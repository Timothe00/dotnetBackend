

namespace Backend.business.DataAccess.Models
{
    public class Matters
    {
        public int MatterId { get; set; }
        public string? MatterName { get; set; }
        public ICollection<MatterTeacher>? MatterTeachers { get; set; }    
    }
}
