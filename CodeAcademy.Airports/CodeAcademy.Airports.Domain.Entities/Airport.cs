using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademy.Airports.Domain.Entities
{
    public class Airport
    {
        public int ID { get; set; }
        
        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(150)]
        public string Country { get; set; }

        [Required]
        [StringLength(150)]
        public string City { get; set; }

        [Required]
        [StringLength(150)]
        public string Address { get; set; }

        [Required]
        [StringLength(150)]
        public string Hotline { get; set; }
        
        public virtual ICollection<BusinessObject> BusinessObjects { get; set; }//One-to-Many

        public override string ToString()
        {
            return City + " (" + Code + ") ";
        }
    }
}
