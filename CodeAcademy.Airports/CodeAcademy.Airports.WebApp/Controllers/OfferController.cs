using CodeAcademy.Airports.Domain.Entities;
using CodeAcademy.Airports.RepositoryEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CodeAcademy.Airports.WebApp.Controllers
{
    public class OfferController : Controller
    {
        GenericRepository<Offer> _offerRepository = new GenericRepository<Offer>();
        GenericRepository<BusinessObject> _businessObjectRepository = new GenericRepository<BusinessObject>();
        // GET: Offer
        [Authorize]
        public ActionResult Edit(int id)
        {
            var offer = _offerRepository.GetById(id);

            if (offer == null)
            {
                return HttpNotFound("Database does not contain offer with that id.");
            }

            if (!offer.BusinessObject.Responsibles.Select(r => r.Email).Contains(User.Identity.Name))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(offer);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Offer offer)
        {
            if (ModelState.IsValid)
            {
                var dbOffer = _offerRepository.GetById(offer.ID);

                if (dbOffer == null || !dbOffer.BusinessObject.Responsibles.Select(r => r.Email).Contains(User.Identity.Name))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                            
                dbOffer.AvailableQuantity = offer.AvailableQuantity;
                dbOffer.DiscountPercentages = offer.DiscountPercentages;
                dbOffer.IsAttractive = offer.IsAttractive;
                dbOffer.Price = offer.Price;
                dbOffer.Title = offer.Title;

                if (_offerRepository.Update(dbOffer))
                {
                    return RedirectToAction("Details", "BusinessObjects", new { id = dbOffer.BusinessObject.ID });
                }
                
            }

            return View(offer);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var offer = _offerRepository.GetById(id);

            if (offer == null)
            {
                return HttpNotFound("Database does not contain offer with that id.");
            }

            if (!offer.BusinessObject.Responsibles.Select(r => r.Email).Contains(User.Identity.Name))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(offer);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Delete(Offer offer)
        {
            var dbOffer = _offerRepository.GetById(offer.ID);

            if (dbOffer == null || !dbOffer.BusinessObject.Responsibles.Select(r => r.Email).Contains(User.Identity.Name))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var businessObjectId = dbOffer.BusinessObject.ID;
            if (_offerRepository.Delete(dbOffer))
            {
                return RedirectToAction("Details", "BusinessObjects", new { id = businessObjectId });
            }
            
            return View(offer);
        }

        [Authorize]
        public ActionResult Create(int businessObjectId)
        {
            var businessObject = _businessObjectRepository.GetById(businessObjectId);

            if (businessObject == null)
            {
                return HttpNotFound("Database does not contain businessObject with that id.");
            }

            if (!businessObject.Responsibles.Select(r => r.Email).Contains(User.Identity.Name))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var offer = new Offer { BusinessObject = businessObject };

            return View(offer);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Offer offer)
        {
            var businessObject = _businessObjectRepository.GetById(offer.BusinessObjectID);

            if (businessObject == null)
            {
                return HttpNotFound("Database does not contain businessObject with that id.");
            }

            if (!businessObject.Responsibles.Select(r => r.Email).Contains(User.Identity.Name))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            if (_offerRepository.Create(offer))
            {
                return RedirectToAction("Details", "BusinessObjects", new { id = offer.BusinessObjectID });
            }
            
            return View(offer);
        }
    }
}