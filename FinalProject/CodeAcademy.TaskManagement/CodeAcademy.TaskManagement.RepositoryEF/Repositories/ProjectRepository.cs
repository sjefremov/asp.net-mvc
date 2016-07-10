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
        ICustomerRepository _customerRepository = new CustomerRepository();

        public bool Create(Project project)
        {
            var dbCustomer = _customerRepository.GetById(project.CustomerId);

            if (dbCustomer != null)
            {
                project.DateCreated = DateTime.Now;
                project.IsActive = true;

                db.Projects.Add(project);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            var dbProject = GetById(id);

            if (dbProject != null)
            {
                dbProject.IsActive = false;
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public List<Project> GetAll()
        {
            return db.Projects
                .Where(p => p.IsActive)
                .OrderByDescending(p => p.DateCreated)
                .ToList();
        }

        public Project GetById(int id)
        {
            return GetAll().FirstOrDefault(p => p.ID == id);
        }

        public bool Update(Project project)
        {
            var dbProject = GetById(project.ID);

            if (dbProject == null)
            {
                return false;
            }

            dbProject.Name = project.Name;

            db.SaveChanges();

            return true;
        }
    }
}
