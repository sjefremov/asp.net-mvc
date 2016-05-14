using EntityFramework.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFramework.WebApp.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        Database db = new Database();
        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.ToList();

            return View(customers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var customer = db.Customers.FirstOrDefault(c => c.ID == id);

            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            if (customer != null && customer.ID > 0)
            {
                var dbCustomer = db.Customers.FirstOrDefault(c => c.ID == customer.ID);
                db.Customers.Remove(dbCustomer);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(customer);
        }
    }
}