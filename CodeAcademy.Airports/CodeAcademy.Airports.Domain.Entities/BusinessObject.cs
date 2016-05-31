using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademy.Airports.Domain.Entities
{
    public class BusinessObject
    {
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        public BusinessObjectType Type { get; set; }

        [Required]
        [Display(Name = "Opening time")]
        [DataType(DataType.Time)]
        public TimeSpan OpeningTime { get; set; }

        [Required]
        [Display(Name = "Closing time")]
        [DataType(DataType.Time)]
        public TimeSpan ClosingTime { get; set; }

        public virtual int AirportID { get; set; }

        public virtual Airport Airport { get; set; }//Many-to-One

        public virtual ICollection<Employee> Responsibles { get; set; }//One-to-Many

        public virtual ICollection<Offer> Offers { get; set; }//One-to-Many
    }

    public enum BusinessObjectType
    {
        CoffeeBar = 0,
        ShoppingPlace = 1,
        GiftStore = 2,
        DutyFreeCenter = 3,
        WorkPlace = 4,
        SleepingChambers = 5,
        Terminals = 6,
        Other = 7
    }
}
