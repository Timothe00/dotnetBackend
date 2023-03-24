

namespace Backend.business.Logic.ModelsImage
{
    public class AdminImage
    {
        //[Table("Admin")]
        public class Admin
        {
            public int AdminId { get; set; }
            public int RoleId { get; set; }
            public string? AdminLname { get; set; }
            public string? AdminFname { get; set; }
            public string? AdminGender { get; set; }
            public string? AdminEmail { get; set; }
            public string? AdminPassword { get; set; }
        }
    }
}