using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.WebApp.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [StringLength(30, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }

        [StringLength(30, MinimumLength = 2)]
        [Required]
        public string Surname { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; } //use for log in

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Password Confirm")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public bool IsVIP { get; set; }

        public string Country { get; set; }
    }
}
