using CodeAcademy.TaskManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAcademy.TaskManagement.Domain.Entities;

namespace CodeAcademy.TaskManagement.RepositoryEF.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        Database db = new Database();
        public bool Create(Project project)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetAll()
        {
            return db.Projects.ToList();
        }

        public Project GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
