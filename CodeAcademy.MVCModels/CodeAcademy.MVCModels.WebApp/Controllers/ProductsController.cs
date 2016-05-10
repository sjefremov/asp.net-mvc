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
        public ActionResult Index(string searchKeyword)
        {
            IEnumerable<Product> products;

            if (string.IsNullOrEmpty(searchKeyword))
            {
                products = db.GetProducts();
            }
            else
            {
                searchKeyword = searchKeyword.ToLower();
                products = db.GetProducts().Where(p => p.Name.ToLower().Contains(searchKeyword));
            }

            return View(products);
        }

        public ActionResult GetProducts(string searchKeyword)
        {
            IEnumerable<Product> products;

            if (string.IsNullOrEmpty(searchKeyword))
            {
                products = db.GetProducts();
            }
            else
            {
                searchKeyword = searchKeyword.ToLower();
                products = db.GetProducts().Where(p => p.Name.ToLower().Contains(searchKeyword));
            }

            return View("Index", products);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            db.CreateNew(product);
            return View();
        }

    }
}