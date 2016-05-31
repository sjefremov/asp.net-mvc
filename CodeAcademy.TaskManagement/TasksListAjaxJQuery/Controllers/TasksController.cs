using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using TasksListAjaxJQuery.Models;

namespace TasksListAjaxJQuery.Controllers
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
            Thread.Sleep(5000);

            db.Tasks.Add(task);
            db.SaveChanges();

            return Json(task.ID, JsonRequestBehavior.AllowGet);
        }
    }
}