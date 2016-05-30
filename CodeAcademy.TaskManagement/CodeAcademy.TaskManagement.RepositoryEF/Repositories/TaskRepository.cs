using CodeAcademy.TaskManagement.Domain.Entities;
using CodeAcademy.TaskManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CodeAcademy.TaskManagement.RepositoryEF.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        Database db = new Database();

        public bool Create(Task task)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Task> GetAll()
        {
            return db.Tasks.ToList();
        }

        public string GetAsigneeName(int taskId)
        {
            throw new NotImplementedException();
        }

        public Task GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<TaskComment> GetComments(int taskId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Task task)
        {
            throw new NotImplementedException();
        }
    }
}
