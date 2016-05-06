using CodeAcademy.ProjectManagament.WebApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CodeAcademy.ProjectManagament.WebApp.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult Index()
        {
            //List of all projects + favorited projects
            //Important: Keep in mind longer list of projects might need pagination

            return View();
        }
        [HttpPost]
        public ActionResult Create(Project project)
        {

            ViewBag.Name = project.Name;
            ViewBag.Description = project.Description;
            ViewBag.Estimate = project.Estimate;

            Projects.Add(project);

            return View();
        }
        
        public ActionResult Create()
        {

            return View();
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Project project = Projects.GetAll().Single(p => p.ID == id);

            if (project == null)
            {
                return HttpNotFound();
            }

            return View(project);
        }

        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProject(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var projectToUpdate = Projects.GetAll().Single(p => p.ID == id);

            if (TryUpdateModel(projectToUpdate, "",
               new string[] { "Name", "Description", "Estimate" }))
            {
                return RedirectToAction("Index");
            }
            return View(projectToUpdate);
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult Favorite(int id, bool favorite)
        {
            return View();
        }
    }
}