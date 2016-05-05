using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademy.ProjectManagament.WebApp.Database
{
    public class Projects
    {
        public List<Project> GetAll()
        {
            return new List<Project>();
        }

        
    }

    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int Estimate { get; set; }
    }

}
