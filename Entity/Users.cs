using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Entity
{
    public class Users
    {
        public int Id { get; set; }
        [Required, MinLength(2), MaxLength(50)]
        public string Username { get; set; } = string.Empty;
        [Required, MinLength(2)]
        public string FirstName { get; set; } = string.Empty;
        [Required, MinLength(2)]
        public string LastName { get; set; } = string.Empty;
        [Required, MinLength(2), MaxLength(50)]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        public int RoleId { get; set; } // Foreign Key

        public Roles? Role { get; set; } // Navigation property    
    }
}