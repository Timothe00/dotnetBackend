using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.business.DataAccess.Models;

namespace Backend.business.Logic.ModelsImage
{
    public class TeacherImage
    {
        //[Table("Teacher")]
        public class Teacher
        {
            public int TeacherId { get; set; }
            public int RoleId { get; set; }
            public string? UsersLname { get; set; }
            public string? UsersFname { get; set; }
            public string? UsersGender { get; set; }
            public string? UsersEmail { get; set; }
            public string? UsersPassword { get; set; }
        }
    }
}