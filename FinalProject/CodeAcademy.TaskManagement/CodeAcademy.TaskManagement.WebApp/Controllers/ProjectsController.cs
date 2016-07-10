using CodeAcademy.TaskManagement.Domain.Entities;
using CodeAcademy.TaskManagement.Domain.Interfaces;
using CodeAcademy.TaskManagement.RepositoryEF.Repositories;
using CodeAcademy.TaskManagement.WebApp.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeAcademy.TaskManagement.WebApp.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        const int pageSize = 20;

        IProjectRepository _projectRepository = new ProjectRepository();
        ICustomerRepository _customerRepository = new CustomerRepository();

        // GET: Projects
        public ActionResult Index(int? page)
        {
            var projects = _projectRepository.GetAll();

            var pageNumber = page ?? 1;

            return View(projects.ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.Customers = _customerRepository.GetAll();

            return PartialView("_Create");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public JsonResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                if (_projectRepository.Create(project))
                    return Json(new { Success = true, Project = ProjectViewModel.FromModel(project) });
            }

            return Json(new { Success = false });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var dbProject = _projectRepository.GetById(id);

            return PartialView("_Edit", dbProject);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public JsonResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                if (_projectRepository.Update(project))
                {
                    var dbProject = _projectRepository.GetById(project.ID);
                    return Json(new { Success = true, Project = ProjectViewModel.FromModel(dbProject) });
                }
            }


            return Json(new { Success = false });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var dbProject = _projectRepository.GetById(id);

            return PartialView("_Delete", dbProject);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ActionName("Delete")]
        public JsonResult DeletePost(int id)
        {
            
                if (_projectRepository.Delete(id))
                {
                return Json(new { Success = true, ProjectId = id });
            }


            return Json(new { Success = false });
        }
    }
}