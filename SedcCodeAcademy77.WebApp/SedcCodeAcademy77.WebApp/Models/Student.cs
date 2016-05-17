using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedcCodeAcademy77.WebApp.Models
{
    public class Student
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
}
