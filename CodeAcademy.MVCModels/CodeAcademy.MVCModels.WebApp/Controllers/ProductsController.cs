using CodeAcademy.MVCModels.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeAcademy.MVCModels.WebApp.Controllers
{
    public class ProductsController : Controller
    {
        Database db = new Database();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.GetProducts();

            return View(products);
        }
    }
}