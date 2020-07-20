using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"(?=.*\d)(?=.*[a - z])(?=.*[A - Z]).{8,}",
            ErrorMessage = "Must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters")]
        public String Password { get; set; }        
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }
        [Required]
        public int ContactNo { get; set; }
    }
}
