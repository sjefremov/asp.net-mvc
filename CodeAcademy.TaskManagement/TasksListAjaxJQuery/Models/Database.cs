using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksListAjaxJQuery.Models
{
    public class Database : DbContext
    {
        public Database()
        {

        }

        public DbSet<Task> Tasks { get; set; }
    }
}
