using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.WebApp.Models
{
    public class Database : DbContext
    {
        public Database()
        {

        }

        public DbSet<Customer> Customers { get; set; }

    }
}
