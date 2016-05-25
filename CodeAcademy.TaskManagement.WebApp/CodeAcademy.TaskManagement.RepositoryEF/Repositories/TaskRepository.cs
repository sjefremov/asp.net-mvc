using CodeAcademy.TaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CodeAcademy.TaskManagement.RepositoryEF.Repositories
{
    public class TaskRepository
    {
        public List<Task> GetAll()
        {

            return new List<Task>();
        }

        public Task GetById(int id)
        {
            return new Task();
        }

        public List<TaskComment> GetComments(int taskId)
        {
            return new List<TaskComment>();
        }

        public string GetAssigneeName(int taskId)
        {
            return string.Empty;
        }

        public bool Create(Task task)
        {
            return false;
        }

        public bool Update(Task task)
        {
            return false;
        }

        public bool Delete(Task task)
        {
            return false;
        }
    }
}
