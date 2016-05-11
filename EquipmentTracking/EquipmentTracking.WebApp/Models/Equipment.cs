using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EquipmentTracking.WebApp.Models
{
    public class Equipment
    {

        public Equipment()
        {
            ID = Guid.NewGuid();
        }

        public Guid ID { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
    }
}