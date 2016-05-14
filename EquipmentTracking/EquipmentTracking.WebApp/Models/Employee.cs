using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EquipmentTracking.WebApp.Models
{
    public class Employee
    {
        public Employee()
        {
            AssignedEquipment = new List<Equipment>();
        }

        public int ID { get; private set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Equipment> AssignedEquipment { get; set; }
    }
}