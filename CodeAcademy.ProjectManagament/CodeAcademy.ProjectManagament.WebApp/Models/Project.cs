using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeAcademy.ProjectManagament.WebApp.Models
{
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