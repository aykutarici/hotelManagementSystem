using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_webapp.Models;

namespace MVC_webapp.Controllers
{
    public class RentCarsController : Controller
    {
        private MVC_HotelProject2Entities db = new MVC_HotelProject2Entities();

        // GET: RentCars
        public ActionResult Index()
        {
            return View(db.RentCars.ToList());
        }

        // GET: RentCars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentCar rentCar = db.RentCars.Find(id);
            if (rentCar == null)
            {
                return HttpNotFound();
            }
            return View(rentCar);
        }

        // GET: RentCars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentCars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarID,serviceID,CarBrand,CustomerID,Price")] RentCar rentCar)
        {
            if (ModelState.IsValid)
            {
                db.RentCars.Add(rentCar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentCar);
        }

        // GET: RentCars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentCar rentCar = db.RentCars.Find(id);
            if (rentCar == null)
            {
                return HttpNotFound();
            }
            return View(rentCar);
        }

        // POST: RentCars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarID,serviceID,CarBrand,CustomerID,Price")] RentCar rentCar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentCar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentCar);
        }

        // GET: RentCars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentCar rentCar = db.RentCars.Find(id);
            if (rentCar == null)
            {
                return HttpNotFound();
            }
            return View(rentCar);
        }

        // POST: RentCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentCar rentCar = db.RentCars.Find(id);
            db.RentCars.Remove(rentCar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
