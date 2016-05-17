using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedcCodeAcademy77.WebApp.Models
{
    public class Course
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfHours { get; set; }

        public virtual int LecturerID { get; set; }

        public virtual Lecturer Lecturer { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
