using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Exercise.WebApp.Models
{
    public class Database
    {
        public Database()
        {
            
        }
        

        public IEnumerable<User> Users
        {
            get
            {
                if (HttpContext.Current.Application["users"] == null)
                {

                    HttpContext.Current.Application["users"] = new List<User>();
                }

                return HttpContext.Current.Application["users"] as List<User>;
            }
            set
            {
                HttpContext.Current.Application["users"] = value;
            }
        }
    }
}
