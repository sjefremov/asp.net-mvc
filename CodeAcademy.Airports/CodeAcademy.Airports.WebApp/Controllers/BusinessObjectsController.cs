using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeAcademy.Airports.Domain.Entities;
using CodeAcademy.Airports.RepositoryEF;
using CodeAcademy.Airports.RepositoryEF.Repositories;

namespace CodeAcademy.Airports.WebApp.Controllers
{
    public class BusinessObjectsController : Controller
    {
        private GenericRepository<BusinessObject> _businessRepository = new GenericRepository<BusinessObject>();
        private GenericRepository<Airport> _airportRepository = new GenericRepository<Airport>();

        //// GET: BusinessObjects
        //public ActionResult Index()
        //{
        //    return View(_businessRepository.GetAll().ToList());
        //}

        // GET: BusinessObjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var businessObject = _businessRepository.GetById(id.Value);
            if (businessObject == null)
            {
                return HttpNotFound();
            }

            return View(businessObject);
        }

        //// GET: BusinessObjects/Create
        //public ActionResult Create()
        //{

            
        //    ViewBag.AirportID = ToSelectList(_airportRepository.GetAll());

        //    return View();
        //}

        //private List<SelectListItem> ToSelectList(IEnumerable<Airport> airports, int? selectedId = null)
        //{
        //    var selectList = selectedId == null ? new SelectList(airports, "ID", "Code").ToList()
        //                                        : new SelectList(airports, "ID", "Code", selectedId).ToList();
        //    selectList.Insert(0, new SelectListItem { Value = "", Selected = false, Text = " - Select airport - " });

        //    return selectList;
        //}

        //// POST: BusinessObjects/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(BusinessObject businessObject)
        //{
        //    if (ModelState.IsValid && _businessRepository.Create(businessObject))
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.AirportID = ToSelectList(_airportRepository.GetAll(), businessObject.AirportID);

        //    return View(businessObject);
        //}
        [Authorize]
        // GET: BusinessObjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var businessObject = _businessRepository.GetById(id.Value);
            if (businessObject == null)
            {
                return HttpNotFound();
            }

            if (!businessObject.Responsibles.Select(r => r.Email).Contains(User.Identity.Name))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(businessObject);
        }

        // POST: BusinessObjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TimeSpan openingTime, TimeSpan closingTime)
        {
            var businessObject = _businessRepository.GetById(id);
            businessObject.OpeningTime = openingTime;
            businessObject.ClosingTime = closingTime;

            if (!businessObject.Responsibles.Select(r => r.Email).Contains(User.Identity.Name))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (_businessRepository.Update(businessObject))
            {
                return RedirectToAction("Details", "Airports", new { id = businessObject.AirportID });
            }

            return View(businessObject);
        }

        //// GET: BusinessObjects/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var businessObject = _businessRepository.GetById(id.Value);
        //    if (businessObject == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(businessObject);
        //}

        //// POST: BusinessObjects/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    var businessObject = _businessRepository.GetById(id);

        //    if (_businessRepository.Delete(businessObject))
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    return View(businessObject);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
