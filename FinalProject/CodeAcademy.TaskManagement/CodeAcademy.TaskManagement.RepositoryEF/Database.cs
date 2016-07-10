using CodeAcademy.TaskManagement.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CodeAcademy.TaskManagement.RepositoryEF
{
    public class Database : IdentityDbContext<User>
    {
        public Database() : base("name=DefaultConnection", throwIfV1Schema: false)
        { }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Customer> Customers { get; set; }
        
        public DbSet<DashboardWidget> DashboardWidgets { get; set; }

        public static Database Create()
        {
            return new Database();
        }
    }
}
