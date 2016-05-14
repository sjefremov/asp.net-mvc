using EntityFramework.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EntityFramework.WebApp.Controllers
{
    public class AccountController : Controller
    {

        Database db = new Database();
        
        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("LogIn");
        }
        [HttpPost]
        public ActionResult LogIn(Customer customer)
        {
            var dbCustomer = 
                db.Customers.FirstOrDefault(c => c.Email.Equals(customer.Email) && c.Password.Equals(customer.Password));

            if (dbCustomer != null)
            {
                FormsAuthentication.SetAuthCookie(customer.Email, true);
                return RedirectToAction("Index", "Customers");
            }

            ViewBag.Error = "Invalid username or password! Please try again.";
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            customer.IsVIP = false;
            if (ModelState.IsValid)
            {
                //FormsAuthentication.

                db.Customers.Add(customer);
                db.SaveChanges();

                return RedirectToAction("LogIn");
            }

            return View();
        }
    }
}