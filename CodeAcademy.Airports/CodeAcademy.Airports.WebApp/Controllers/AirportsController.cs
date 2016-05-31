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
    public class AirportsController : Controller
    {
        private GenericRepository<Airport> _airportRepository = new GenericRepository<Airport>();

        // GET: Airports
        public ActionResult Index()
        {
            return View(_airportRepository.GetAll().ToList());
        }

        // GET: Airports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var airport = _airportRepository.GetById(id.Value);
            if (airport == null)
            {
                return HttpNotFound();
            }

            return View(airport);
        }

        //// GET: Airports/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Airports/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Airport airport)
        //{
        //    if (ModelState.IsValid && _airportRepository.Create(airport))
        //    {   
        //        return RedirectToAction("Index");
        //    }

        //    return View(airport);
        //}

        //// GET: Airports/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var airport = _airportRepository.GetById(id.Value);
        //    if (airport == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(airport);
        //}

        //// POST: Airports/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Airport airport)
        //{
        //    if (ModelState.IsValid && _airportRepository.Update(airport))
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View(airport);
        //}

        //// GET: Airports/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var airport = _airportRepository.GetById(id.Value);
        //    if (airport == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(airport);
        //}

        //// POST: Airports/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    var airport = _airportRepository.GetById(id);

        //    if(_airportRepository.Delete(airport))
        //    {
        //        return RedirectToAction("Index");
        //    }
            
        //    return View(airport);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _airportRepository.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
