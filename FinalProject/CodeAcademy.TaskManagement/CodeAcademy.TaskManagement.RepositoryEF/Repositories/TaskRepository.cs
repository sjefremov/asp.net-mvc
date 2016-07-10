using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeAcademy.TaskManagement.Domain.Entities;
using CodeAcademy.TaskManagement.Domain.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeAcademy.TaskManagement.RepositoryEF.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        Database db = new Database();
        IProjectRepository _projectRepsitory = new ProjectRepository();
        IUserRepository _userRepository = new UserRepository();
        
        public bool Create(Task task)
        {
            //in what project this task belongs?
            if (task.ProjectId <= 0)
                return false;

            var dbProject = _projectRepsitory.GetById(task.ProjectId);

            if (dbProject == null)
                return false;
            //else task.Project = dbProject;

            //user assigned check
            if (string.IsNullOrEmpty(task.UserId))
                return false;

            var dbUser = _userRepository.GetById(task.UserId);

            if (dbUser == null)
                return false;
            //else task.User = dbUser;

            task.IsActive = true;
            task.DateCreated = DateTime.Now;

            //adding the task to DB collection
            db.Tasks.Add(task);

            //save the task
            db.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var dbTask = GetById(id);

            if (dbTask == null)
                return false;

            dbTask.IsActive = false;
            db.SaveChanges();

            return true;
        }

        public List<Task> GetAll()
        {
            return db.Tasks
                        .Where(t => t.IsActive)
                        .OrderByDescending(t => t.DateCreated)
                        .ToList();
        }

        public string GetAssigneeName(int taskId)
        {
            var dbTask = GetById(taskId);

            if (dbTask == null)
                return string.Empty;

            return dbTask.User.DisplayName + "(" + dbTask.User.Email + ")";
        }

        public Task GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }

        public List<Task> GetByProject(int projectId)
        {
            return GetAll().Where(p => p.ProjectId == projectId).ToList();
        }

        public List<TaskComment> GetComments(int taskId)
        {
            var dbTask = GetById(taskId);

            if (dbTask != null)
                return dbTask.Comments.ToList();
            else
                return new List<TaskComment>();
        }

        public bool Update(Task task)
        {
            var dbTask = GetById(task.ID);

            if (dbTask == null)
                return false;

            if (dbTask.Status != task.Status)
            {
                if (!IsAllowedMoving(dbTask.Status, task.Status))
                {
                    return false;
                }
            }

            //all data columns we want to update
            dbTask.Description = task.Description;
            dbTask.Name = task.Name;
            dbTask.Type = task.Type;
            
            dbTask.Status = task.Status;
            dbTask.StartDate = task.StartDate;
            dbTask.EndDate = task.EndDate;

            //commit changes to database
            db.SaveChanges();

            return true;
        }

        /// <summary>
        /// returns whether is allowed moving from oldStatus to newStatus
        /// </summary>
        /// <param name="oldStatus"></param>
        /// <param name="newStatus"></param>
        /// <returns></returns>
        private bool IsAllowedMoving(TaskStatus oldStatus, TaskStatus newStatus)
        {
            var allowedMovings = new Dictionary<TaskStatus, ICollection<TaskStatus>>
            {
                { TaskStatus.ToDo, new List<TaskStatus> { TaskStatus.InProgress, TaskStatus.InTesting } },
                { TaskStatus.InProgress, new List<TaskStatus> { TaskStatus.ToDo, TaskStatus.InTesting, TaskStatus.Done } },
                { TaskStatus.InTesting, new List<TaskStatus> { TaskStatus.ToDo, TaskStatus.Done } },
                { TaskStatus.Done, new List<TaskStatus> { TaskStatus.InProgress, TaskStatus.InTesting, TaskStatus.ToDo } },
            };

            return allowedMovings[oldStatus].Contains(newStatus);
        }
    }
}
