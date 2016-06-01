using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TasksListAjaxjQueryApp.Models
{
    public class Database : DbContext
    {
        public Database()
        { }

        public DbSet<Task> Tasks { get; set; }
    }
}