using CodeAcademy.Airports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademy.Airports.RepositoryEF
{
    public class Database : DbContext
    {
        public Database()
        {

        }

        public DbSet<Airport> Airports { get; set; }

        public DbSet<BusinessObject> BusinessObjects { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Offer> Offers { get; set; }
    }
}
