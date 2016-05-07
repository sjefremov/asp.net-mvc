using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeAcademy.RazorAndViews.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var texts = new List<string>
            {
                "Hello, right now I'm writing C# code for ASP.NET MVC.",
                "This MVC seems fun",
                "I like writing code in .NET Framework",
                "Razor view engine seems awsome"
            };

            return View(texts);
        }

        public ActionResult Exercise()
        {
            var texts = new List<string>
            {
                "Hello, right now I'm writing C# code for ASP.NET MVC.",
                "This MVC seems fun",
                "I like writing code in .NET Framework",
                "Razor view engine seems awsome",
                "Hello, right now I'm writing C# code for ASP.NET MVC.",
                "This MVC seems fun",
                "I like writing code in .NET Framework",
                "Razor view engine seems awsome",
                "Hello, right now I'm writing C# code for ASP.NET MVC.",
                "This MVC seems fun",
                "I like writing code in .NET Framework",
                "Razor view engine seems awsome"
            };

            return View(texts);
        }


    }
}