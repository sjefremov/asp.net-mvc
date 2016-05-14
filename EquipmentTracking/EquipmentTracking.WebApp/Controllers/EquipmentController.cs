using EquipmentTracking.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EquipmentTracking.WebApp.Controllers
{
    public class EquipmentController : Controller
    {
        private DatabaseOld databaseOld = new DatabaseOld();

        private Database db = new Database();

        // GET: Equipment
        public ActionResult Index(string query)
        {
            var equipment = db.Equipment.AsQueryable();

            if (!string.IsNullOrEmpty(query))
            {
                equipment = equipment.Where(e => e.Name.ToLower().Contains(query.ToLower()));
                ViewBag.Query = query;
            }
            
            return View(equipment.ToList());
        }

        public ActionResult Index2(string query)
        {
            var equipment = databaseOld.GetEquipment();

            if (!string.IsNullOrEmpty(query))
            {
                equipment = equipment.Where(e => e.Name.ToLower().Contains(query.ToLower()));
                ViewBag.Query = query;
            }

            return View(equipment);
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
    }
}