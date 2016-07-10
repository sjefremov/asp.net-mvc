using CodeAcademy.TaskManagement.Domain.Interfaces;
using CodeAcademy.TaskManagement.RepositoryEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeAcademy.TaskManagement.WebApp.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private IUserRepository _userRepository = new UserRepository();

        public ActionResult ReportForTasks()
        {
            var users = _userRepository.GetAll().OrderByDescending(u => u.Tasks.Count);

            return View(users);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult PendingApproval()
        {
            var users = _userRepository.GetAll().Where(u => u.PendingApproval);
            return View(users);
        }
    }
}