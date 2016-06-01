using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasksListAjaxjQueryApp.Models;

namespace TasksListAjaxjQueryApp.Controllers
{
    public class TasksController : Controller
    {
        Database db = new Database();

        // GET: Tasks
        public ActionResult Index()
        {
            var tasks = db.Tasks.ToList();

            return View(tasks);
        }

        public JsonResult Add(Task task)
        {
            //System.Threading.Thread.Sleep(5000);

            db.Tasks.Add(task);
            db.SaveChanges();

            return Json(task.ID, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            var dbEntity = db.Tasks.FirstOrDefault(x => x.ID == id);

            if (dbEntity != null)
            {
                db.Tasks.Remove(dbEntity);
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}