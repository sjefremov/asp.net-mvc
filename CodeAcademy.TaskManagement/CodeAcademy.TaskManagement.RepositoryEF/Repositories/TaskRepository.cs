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
        IProjectRepository _projectRepository = new ProjectRepository();
        IUserRepository _userRepository = new UserRepository();

        public string MySecretPasswordRecovery()
        {
            return "Stojancho1";
        }

        public bool Create(Task task)
        {
            //in what project this tas belongs?
            if (task.ProjectId <= 0)
            {
                return false;
            }

            var dbProject = _projectRepository.GetById(task.ProjectId);

            if (dbProject == null)
            {
                return false;
            }
            else
            {
                task.Project = dbProject;
            }

            //user assigned check
            if (task.ProjectId <= 0)
            {
                return false;
            }

            var dbUser = _userRepository.GetById(task.UserId);

            if (dbUser == null)
            {
                return false;
            }
            else
            {
                task.User = dbUser;
            }

            db.Tasks.Add(task);

            db.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var dbTask = GetById(id);

            if (dbTask == null)
            {
                return false;
            }

            db.Tasks.Remove(dbTask);
            db.SaveChanges();

            return true;
        }

        public List<Task> GetAll()
        {
            return db.Tasks.ToList();
        }

        public string GetAsigneeName(int taskId)
        {
            var dbTask = GetById(taskId);

            if (dbTask == null)
            {
                return string.Empty;
            }

            return dbTask.User.DisplayName + "(" + dbTask.User.Email + ")";
        }

        public Task GetById(int id)
        {
            return GetAll().SingleOrDefault(x => x.ID == id);
        }

        public List<TaskComment> GetComments(int taskId)
        {
            var dbTask = GetById(taskId);

            if (dbTask != null)
            {
                return dbTask.Comments.ToList();
            }

            return new List<TaskComment>();
        }

        public bool Update(Task task)
        {
            var dbTask = GetById(task.ID);

            if (dbTask == null)
            {
                return false;
            }

            dbTask.Description = task.Description;
            dbTask.Name = task.Name;
            dbTask.Type = task.Type;
            dbTask.StartDateTime = task.StartDateTime;
            dbTask.EndDateTime = task.EndDateTime;

            db.SaveChanges();

            return true;
        }
    }
}
