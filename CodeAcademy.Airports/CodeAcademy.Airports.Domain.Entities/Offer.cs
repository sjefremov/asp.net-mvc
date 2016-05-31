using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademy.Airports.Domain.Entities
{
    public class Offer
    {
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "AvailableQuantity")]
        public int AvailableQuantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool IsAttractive { get; set; }

        [Display(Name = "Discount Percentages")]
        public byte DiscountPercentages { get; set; }

        public virtual int BusinessObjectID { get; set; }

        public virtual BusinessObject BusinessObject { get; set; }//Many-to-One
    }
}
