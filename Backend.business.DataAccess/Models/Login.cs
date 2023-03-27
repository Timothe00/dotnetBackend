using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Backend.business.DataAccess.Models
{
    public class Login
    {
        [Required(ErrorMessage = "UsersEmail is required")]        
        public string? UsersEmail { get; set; }

        [Required(ErrorMessage = "UsersPassword is required")]
        public string? UsersPassword { get; set; }
    }
}