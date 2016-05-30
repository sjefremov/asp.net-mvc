using CodeAcademy.TaskManagement.Domain.Interfaces;
using CodeAcademy.TaskManagement.RepositoryEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeAcademy.TaskManagement.WebApp.Controllers
{
    public class TasksController : Controller
    {
        public ITaskRepository _taskRepository = new TaskRepository();
        // GET: Tasks
        public ActionResult Index()
        {
            var tasks = _taskRepository.GetAll();

            return View(tasks);
        }
    }
}