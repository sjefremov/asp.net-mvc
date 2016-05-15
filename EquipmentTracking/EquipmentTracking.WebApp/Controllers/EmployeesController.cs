using EquipmentTracking.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EquipmentTracking.WebApp.Controllers
{
    public class EmployeesController : Controller
    {
        Database db = new Database();
        // GET: Employees
        public ActionResult Index(string query)
        {
            var employees = db.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(query))
            {
                employees = employees.Where(e => e.Name.ToLower().Contains(query.ToLower()));
                ViewBag.Query = query;
            }

            return View(employees.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = db.Employees.SingleOrDefault(e => e.ID == id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }
    }
}