using CodeAcademy.ProjectManagament.WebApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Update()
        {
            return View();
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