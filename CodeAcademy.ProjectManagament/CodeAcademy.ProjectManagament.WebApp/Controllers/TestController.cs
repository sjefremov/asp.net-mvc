using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeAcademy.ProjectManagament.WebApp.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Names()
        {
            var names = new List<string>
            {
                "Chuck Norris",
                "Iron Man",
                "Hulk",
                "Bruce Lee"
            };

            return View(names);
        }
    }
}