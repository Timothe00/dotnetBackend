﻿

namespace Backend.business.DataAccess.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; set; } 
        public string? UsersLname { get; set; }
        public string? UsersFname { get; set; }
        public string? UsersGender { get; set; }
        public string? UsersEmail { get; set; }
        public string? UsersPassword { get; set; }
    }
}
