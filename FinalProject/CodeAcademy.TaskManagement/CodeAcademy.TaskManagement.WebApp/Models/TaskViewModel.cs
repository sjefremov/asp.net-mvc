using CodeAcademy.TaskManagement.Domain.Entities;
using CodeAcademy.TaskManagement.Domain.Interfaces;
using CodeAcademy.TaskManagement.RepositoryEF.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeAcademy.TaskManagement.WebApp.Models
{
    public class TaskViewModel
    {
        static IProjectRepository _projectRepository = new ProjectRepository();
        static IUserRepository _userRepository = new UserRepository();

        public int ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Estimated hours")]
        public int EstimatedHours { get; set; }

        [Display(Name = "Start date")]
        public string StartDate { get; set; }

        [Display(Name = "End date")]
        public string EndDate { get; set; }

        //[JsonConverter(typeof(StringEnumConverter))]
        public string Type { get; set; }

        //[JsonConverter(typeof(StringEnumConverter))]
        public string Status { get; set; }
        
        public string Project { get; set; }

        public string User { get; set; }

        public static TaskViewModel FromModel(Task task)
        {
            return new TaskViewModel
            {
                ID = task.ID,
                Description = task.Description,
                EndDate = task.EndDate.HasValue ? task.EndDate.Value.ToString("yyyy-MM-dd") : "",
                EstimatedHours = task.EstimatedHours,
                Name = task.Name,
                Project = task.Project == null ? _projectRepository.GetById(task.ProjectId).Name : task.Project.Name,
                StartDate = task.StartDate.HasValue ? task.StartDate.Value.ToString("yyyy-MM-dd") : "",
                Status = task.Status.ToString(),
                Type = task.Type.ToString(),
                User = task.User == null ? _userRepository.GetById(task.UserId).DisplayName : task.User.DisplayName
            };
        }
    }
}