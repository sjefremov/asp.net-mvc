using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFirstProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Name = "Stojancho";
            ViewBag.Color = "#999";
            return View();
        }

        public ActionResult List()
        {
            var people = new List<string> { "Pavle", "Stojancho", "Trajko", "Petko", "Mitra", "Vera", "Stojko" };
            ViewBag.People = people;
            return View();
        }
    }
}