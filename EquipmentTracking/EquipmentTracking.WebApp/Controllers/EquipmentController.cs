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
        private Database database = new Database();
        // GET: Equipment
        public ActionResult Index(string query)
        {
            var equipment = database.GetEquipment();

            if (!string.IsNullOrEmpty(query))
            {
                equipment = equipment.Where(e => e.Name.ToLower().Contains(query.ToLower()));
                ViewBag.Query = query;
            }
            
            return View(equipment);
        }
    }
}