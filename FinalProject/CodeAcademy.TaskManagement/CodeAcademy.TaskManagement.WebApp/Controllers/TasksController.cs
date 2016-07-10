using CodeAcademy.TaskManagement.Domain.Entities;
using CodeAcademy.TaskManagement.Domain.Interfaces;
using CodeAcademy.TaskManagement.RepositoryEF.Repositories;
using CodeAcademy.TaskManagement.WebApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeAcademy.TaskManagement.WebApp.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        ITaskRepository _taskRepository = new TaskRepository();
        IProjectRepository _projectRepository = new ProjectRepository();
        IUserRepository _userRepository = new UserRepository();
        // GET: Tasks
        public ActionResult Index(int projectId)
        {
            var tasks = _taskRepository.GetByProject(projectId);

            ViewBag.Project = _projectRepository.GetById(projectId);

            return View(tasks);
        }

        public ActionResult Create(int projectId)
        {
            ViewBag.Project = _projectRepository.GetById(projectId);
            ViewBag.Users = _userRepository.GetAll();

            return PartialView("_Create", new Task());
        }

        [HttpPost]
        public JsonResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                if (_taskRepository.Create(task))
                {
                    var tasks = _taskRepository.GetByProject(task.ProjectId);

                    ViewBag.Project = _projectRepository.GetById(task.ProjectId);

                    //task.User = _userRepository.GetById(task.UserId);

                    //var serializedTask = JsonConvert.SerializeObject(task, new StringEnumConverter());

                    return Json(new { Success = true, Task = TaskViewModel.FromModel(task) });
                    //return RedirectToAction("Index", new { projectId = task.ProjectId });
                }
            }

            return Json(new { Success = false });
        }
        
        public ActionResult Edit(int id)
        {
            var dbTask = _taskRepository.GetById(id);

            //ViewBag.Projects = _projectRepository.GetAll();
            //ViewBag.Users = _userRepository.GetAll();

            return PartialView("_Edit", dbTask);
        }

        [HttpPost]
        public JsonResult Edit(Task task)
        {
            if (ModelState.IsValid)
            {
                if (_taskRepository.Update(task))
                {
                    var dbTask = _taskRepository.GetById(task.ID);
                    return Json(new { Success = true, Task = TaskViewModel.FromModel(dbTask) });
                }
            }
            
            return Json(new { Success = false });
        }

        public ActionResult Delete(int id)
        {
            var dbTask = _taskRepository.GetById(id);

            return PartialView("_Delete", dbTask);
        }

        [HttpPost]
        [ActionName("Delete")]
        public JsonResult DeletePost(int id)
        {
            var projectId = _taskRepository.GetById(id).ProjectId;

            if (_taskRepository.Delete(id))
            {
                return Json(new { Success = true, TaskId = id });
            }

            return Json(new { Success = false });
        }
    }
}