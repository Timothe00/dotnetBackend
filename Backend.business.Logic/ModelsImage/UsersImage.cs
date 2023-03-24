

using Backend.business.DataAccess.Models;

namespace Backend.business.Logic.ModelsImage
{
     //public class UsersImage
     //{
     //       public int UserId { get; set; }
     //       public int RoleId { get; set; }
     //       public Role? Role { get; set; }
     //        public string? UserLname { get; set; }
     //       public string? UserFname { get; set; }
     //       public string? UserGender { get; set; }
     //        public string? UserEmail { get; set; }
     //        public string? UserPassword { get; set; }
     //}


    public class ImagePost
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string? UserLname { get; set; }
        public string? UserFname { get; set; }
        public string? UserGender { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
    }
}