using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SedcCodeAcademy77.WebApp.Models
{
    public class SedcCodeAcademy77WebAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SedcCodeAcademy77WebAppContext() : base("name=SedcCodeAcademy77WebAppContext")
        {
        }

        public System.Data.Entity.DbSet<SedcCodeAcademy77.WebApp.Models.Lecturer> Lecturers { get; set; }
    }
}
