using Exercise.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercise.WebApp.Controllers
{
    public class UsersController : Controller
    {
        Database db = new Database();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.ToList();

            ViewBag.Users = users.ToList();

            return View();
        }
        [HttpPost]
        public ActionResult Index(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                var users = db.Users.ToList();

                var resetUser = users.SingleOrDefault(u => u.Email.Equals(email));

                if (resetUser == null)
                {
                    resetUser = new User { Email = email, ResetToken = Guid.NewGuid().ToString() };
                    users.Add(resetUser);
                }
                else
                {
                    if (string.IsNullOrEmpty(resetUser.ResetToken))
                    {
                        resetUser.ResetToken = Guid.NewGuid().ToString();
                    }
                }

                ViewBag.Users = users.ToList();

                db.Users = users;
            }
            return View();
        }

        public ActionResult Reset(string resetToken)
        {
            var users = db.Users.ToList();

            var resetUser = users.SingleOrDefault(u => u.ResetToken.Equals(resetToken));

            if (resetUser == null)
            {
                ViewBag.Users = users.ToList();
                return RedirectToAction("Index");
            }

            ViewBag.ResetToken = resetToken;

            return View();
        }

        [HttpPost, ActionName("Reset")]
        public ActionResult ResetPost(string password, string resetToken)
        {
            var users = db.Users.ToList();

            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(resetToken))
            {
                ViewBag.Users = users.ToList();
                return RedirectToAction("Index");
            }

            var resetUser = users.SingleOrDefault(u => u.ResetToken.Equals(resetToken));

            if (resetUser == null)
            {
                ViewBag.Users = users.ToList();
                return RedirectToAction("Index");
            }

            resetUser.Password = password;
            resetUser.ResetToken = null;

            db.Users = users;

            return RedirectToAction("Index");

            return View();
        }
    }
}