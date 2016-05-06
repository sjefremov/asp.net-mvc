using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAcademy.ProjectManagament.WebApp.Database
{
    public class Projects
    {
        private static List<Project> projects;

        static Projects()
        {
            Init();
        }

        public static void Init()
        {
            projects = new List<Project>();

            projects.Add(new Project
            {
                Name = "A",
                Estimate = 100,
                Description = "Project A Description"
            });

            projects.Add(new Project
            {
                Name = "B",
                Estimate = 300,
                Description = "Project B Description"
            });

            projects.Add(new Project
            {
                Name = "C",
                Estimate = 400,
                Description = "Project C Description"
            });

            projects.Add(new Project
            {
                Name = "D",
                Estimate = 700,
                Description = "Project D Description"
            });
        }

        public static List<Project> GetAll()
        {
            return projects;
        }

        public static void Add(Project p)
        {
            projects.Add(p);
        }
    }

    public class Project
    {
        private static int nextID;

        static Project()
        {
            nextID = 0;
        }

        public Project()
        {
            ID = nextID++;
        }

        public int ID { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Estimate { get; set; }
    }

}
