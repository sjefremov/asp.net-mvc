using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EquipmentTracking.WebApp.Models
{
    public class Equipment
    {

        public Equipment()
        {
            
        }

        public int ID { get; set; }

        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(100)]
        public string Category { get; set; }

        public int? EmployeeID { get; set; }

        public virtual Employee AssignedTo { get; set; }
    }
}