using CodeAcademy.TaskManagement.Domain.Entities;
using CodeAcademy.TaskManagement.Domain.Interfaces;
using CodeAcademy.TaskManagement.RepositoryEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeAcademy.TaskManagement.WebApp.Controllers
{
    public class CustomersController : Controller
    {
        ICustomerRepository _customerRepository = new CustomerRepository();
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _customerRepository.GetAll();

            return View(customers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (_customerRepository.Create(customer))
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }
    }
}