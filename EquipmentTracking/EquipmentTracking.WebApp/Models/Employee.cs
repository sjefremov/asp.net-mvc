using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EquipmentTracking.WebApp.Models
{
    public class Employee
    {
        public Employee(string name)
        {
            ID = Guid.NewGuid();
            Name = name;
        }

        public Guid ID { get; private set; }

        public string Name { get; set; }
    }
}