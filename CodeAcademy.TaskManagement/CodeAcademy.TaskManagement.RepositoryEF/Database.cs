using CodeAcademy.TaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CodeAcademy.TaskManagement.RepositoryEF
{
    public class Database : DbContext
    {
        public Database()
        {

        }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }
}
