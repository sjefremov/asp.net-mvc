using CodeAcademy.TaskManagement.Domain.Entities;
using CodeAcademy.TaskManagement.RepositoryEF.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CodeAcademy.TaskManagement.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer(new MyDbInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
    }

    public class MyDbInitializer : DropCreateDatabaseIfModelChanges<RepositoryEF.Database>
    {
        protected override void Seed(RepositoryEF.Database context)
        {
            //#region addingAdmin
            //var userManager = new UserManager<User>(new UserStore<User>(context));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //string name = "Admin";
            //string email = name + "@gmail.com";
            //string password = "Password1!";

            //if (!roleManager.RoleExists(name))
            //{
            //    roleManager.Create(new IdentityRole(name));
            //}

            //var user = new User();
            //user.UserName = email;
            //user.IsActive = true;
            //user.PendingApproval = false;
            //user.DateCreated = DateTime.Now;
            //user.DisplayName = name;
            //user.Email = email;

            //var adminResult = userManager.Create(user, password);

            //if (adminResult.Succeeded)
            //{
            //    userManager.AddToRole(user.Id, name);
            //}
            //#endregion
            
            base.Seed(context);
        }
    }
}
