using CodeAcademy.TaskManagement.Domain.Interfaces;
using CodeAcademy.TaskManagement.RepositoryEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeAcademy.TaskManagement.WebApp.Controllers
{
    public class DashboardController : Controller
    {
        IDashboardWidgetRepository _dashboardWidgetRepository = new DashboardWidgetRepository();
        // GET: Dashboard
        public ActionResult Index(int id)//id = userID
        {
            var widgets = _dashboardWidgetRepository.GetAll(id);

            return View(widgets);
        }

        public JsonResult SetSize(int userId, int itemId, int size)//id = userID
        {
            var dbWidget = _dashboardWidgetRepository.GetById(userId, itemId);

            if (dbWidget != null)
            {
                dbWidget.Size = (Domain.Entities.WidgetSize)size;
                _dashboardWidgetRepository.Update(userId, dbWidget);

                return Json(dbWidget, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}