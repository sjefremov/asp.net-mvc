using CodeAcademy.TaskManagement.Domain.Entities;
using CodeAcademy.TaskManagement.Domain.Interfaces;
using CodeAcademy.TaskManagement.RepositoryEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeAcademy.TaskManagement.WebApp.Controllers
{
    public class ProjectsController : Controller
    {
        IProjectRepository _projectRepository = new ProjectRepository();
        // GET: Projects
        public ActionResult Index()
        {
            var projects = _projectRepository.GetAll();

            return View(projects);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                if (_projectRepository.Create(project))
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }
    }

}