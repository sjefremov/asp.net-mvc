using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EquipmentTracking.WebApp.Models
{
    public class Database : DbContext
    {
        public Database()
        {

        }

        public DbSet<Equipment> Equipment { get; set; }

        public DbSet<Employee> Employees { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Equipment>()
        //            .HasOptional<Employee>(eq => eq.AssignedTo)
        //            .WithMany(em => em.AssignedEquipment);
        //}
    }
}