

namespace Backend.business.DataAccess.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public virtual ICollection<Users>? Users { get; set; }
    }
}
