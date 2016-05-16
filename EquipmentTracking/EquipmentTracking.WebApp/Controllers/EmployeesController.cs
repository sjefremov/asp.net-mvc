using EquipmentTracking.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
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

        [HttpPost, ActionName("Edit")]
        public ActionResult EditPost(int? id)
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

            if (TryUpdateModel(employee, "", new string[] { "Name" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }

            return View(employee);
        }

        public ActionResult Delete(int? id)
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

        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var employee = db.Employees.SingleOrDefault(c => c.ID == id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            db.Employees.Remove(employee);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
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