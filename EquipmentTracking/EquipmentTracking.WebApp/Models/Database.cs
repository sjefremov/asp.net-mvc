using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EquipmentTracking.WebApp.Models
{
    public class Database
    {
        public Database()
        {
            if (HttpContext.Current.Application["equipment"] == null)
            {
                HttpContext.Current.Application["equipment"] = GetEquipment();
            }


        }

        private IEnumerable<Equipment> GetEquipment()
        {
            if (HttpContext.Current.Application["equipment"] != null)
            {
                return HttpContext.Current.Application["equipment"] as List<Equipment>;
            }
            else
            {
                var equipment = new List<Equipment>
                {
                    new Equipment
                    {
                        Name = "Laptop Lenovo",
                        Description = "Laptop Lenovo Series A, CPU i7, 8GB RAM, 500GB SSD",
                        Category = "Computers"
                    },
                    new Equipment
                    {
                        Name = "Laptop Dell",
                        Description = "Laptop Dell Series Z, CPU i5, 8GB RAM, 500GB SSD",
                        Category = "Computers"
                    },
                    new Equipment
                    {
                        Name = "Monitor",
                        Description = "Monitor 19\" Lenovo ThinkVision E1922 1366x768 VGA",
                        Category = "Monitors"
                    },
                    new Equipment
                    {
                        Name = "Monitor",
                        Description = "Monitor 19\" Lenovo ThinkVision E1922 1366x768 VGA",
                        Category = "Monitors"
                    }
                };

                HttpContext.Current.Application["equipment"] = equipment;

                return equipment;
            }
        }
    }
}