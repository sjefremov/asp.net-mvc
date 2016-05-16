using EquipmentTracking.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EquipmentTracking.WebApp.Controllers
{
    public class EquipmentController : Controller
    {
        private Database db = new Database();

        // GET: Equipment
        public ActionResult Index(string queryByName, int? employeeID)
        {
            var equipment = db.Equipment.AsQueryable();

            if (!string.IsNullOrEmpty(queryByName))
            {
                equipment = equipment.Where(e => e.Name.ToLower().Contains(queryByName.ToLower()));
                ViewBag.Query = queryByName;
            }

            var assignees = db.Employees.Where(e => e.AssignedEquipment.Count > 0).AsQueryable();
            ViewBag.FilteredByEmployee = false;

            if (employeeID != null)
            {
                equipment = equipment.Where(e => e.EmployeeID == employeeID);
                assignees = assignees.Where(a => a.ID == employeeID);
                ViewBag.FilteredByEmployee = true;
            }
            
            ViewBag.Assignees = assignees.ToList();
            
            return View(equipment.ToList());
        }
       
        public ActionResult Create()
        {
            var employeesList = new SelectList(db.Employees, "ID", "Name").ToList();
            employeesList.Insert(0, new SelectListItem { Value = "", Selected = false, Text = " - Select employee - " });

            ViewBag.EmployeeID = employeesList;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                db.Equipment.Add(equipment);
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

            var equipment = db.Equipment.SingleOrDefault(e => e.ID == id);

            if (equipment == null)
            {
                return HttpNotFound();
            }

            var employeesList = new SelectList(db.Employees, "ID", "Name", equipment.EmployeeID).ToList();
            employeesList.Insert(0, new SelectListItem { Value = "", Selected = false, Text = " - Select employee - " });

            ViewBag.EmployeeID = employeesList;

            return View(equipment);
        }

        [HttpPost]
        public ActionResult Edit(Equipment equipment)
        {
            if (equipment == null || equipment.ID < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Equipment.Attach(equipment);
                    db.Entry(equipment).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
                
            }

            var employeesList = new SelectList(db.Employees, "ID", "Name", equipment.EmployeeID).ToList();
            employeesList.Insert(0, new SelectListItem { Value = "", Selected = false, Text = " - Select employee - " });

            ViewBag.EmployeeID = employeesList;

            return View(equipment);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var equipment = db.Equipment.SingleOrDefault(e => e.ID == id);

            if (equipment == null)
            {
                return HttpNotFound();
            }

            return View(equipment);
        }

        [HttpPost]
        public ActionResult Delete(Equipment equipment)
        {
            if (equipment == null || equipment.ID < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                db.Equipment.Attach(equipment);
                db.Equipment.Remove(equipment);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return View(equipment);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var equipment = db.Equipment.SingleOrDefault(e => e.ID == id);

            if (equipment == null)
            {
                return HttpNotFound();
            }

            return View(equipment);
        }

        public ActionResult LogIn()
        {
            if (HttpContext.Session["invalidTries"] == null)
            {
                HttpContext.Session["invalidTries"] = 0;
            }

            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string username, string password)
        {
            if (HttpContext.Session["invalidTries"] == null)
            {
                HttpContext.Session["invalidTries"] = 0;
            }

            if (username.Equals("admin") && password.Equals("admin#123"))
            {
                return RedirectToAction("Index");
            }

            HttpContext.Session["invalidTries"] = (int)HttpContext.Session["invalidTries"] + 1;

            if ((int)HttpContext.Session["invalidTries"] > 5)
            {
                HttpContext.Session.Timeout = 30;
            }
            
            return View();
        }
    }
}