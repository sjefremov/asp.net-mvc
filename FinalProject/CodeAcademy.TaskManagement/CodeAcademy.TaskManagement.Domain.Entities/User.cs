using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademy.TaskManagement.Domain.Entities
{
    public class User : IdentityUser//, BaseEntity
    {

        public User()
        {
            Tasks = new List<Task>();
        }

        public bool IsActive { get; set; }

        public bool PendingApproval { get; set; }

        public DateTime DateCreated { get; set; }
        
        [Required]
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
