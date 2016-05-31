using CodeAcademy.Airports.Domain.Entities;
using CodeAcademy.Airports.RepositoryEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CodeAcademy.Airports.WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        GenericRepository<Employee> _emmployeeRepository = new GenericRepository<Employee>();
        // GET: Admin
        public ActionResult LogIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Airports");
            }

            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string email, string password)
        {
            var employee = _emmployeeRepository.GetAll()
                                .SingleOrDefault(e => e.Email.Equals(email) && e.Password.Equals(password));

            if (employee != null)
            {
                FormsAuthentication.SetAuthCookie(email, true);
                return RedirectToAction("Index", "Airports");
            }

            ViewBag.HasError = true;
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Airports");
        }
    }
}