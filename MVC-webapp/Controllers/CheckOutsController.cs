using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_webapp.Models;
using MVC_webapp.Util;

namespace MVC_webapp.Controllers
{
    public class CheckOutsController : BaseController
    {
        private MVC_HotelProject2Entities db = new MVC_HotelProject2Entities();

        // GET: CheckOuts
        public ActionResult Index()
        {
            var checkOuts = db.CheckOuts.Include(c => c.CheckIn).Include(c => c.Room).Include(c => c.Customer);
            return View(checkOuts.ToList());
        }

        // GET: CheckOuts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckOut checkOut = db.CheckOuts.Find(id);
            if (checkOut == null)
            {
                return HttpNotFound();
            }
            return PartialView(checkOut);
        }

        // GET: CheckOuts/Create
        public ActionResult Create()
        {
            ViewBag.CheckInID = new SelectList(db.CheckIns, "CheckInID", "CheckInID");
            ViewBag.RoomNum = new SelectList(db.Rooms, "RoomNum", "RoomNum");
            ViewBag.customerID = new SelectList(db.Customers, "CustomerID", "Name");
           
            return View();
        }

        // POST: CheckOuts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CheckOutID,CheckOutDate,CheckInID,RoomNum,customerID,noadults,nochild,passportnum")] CheckOut checkOut)
        {
            if (ModelState.IsValid)
            {
                db.CheckOuts.Add(checkOut);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CheckInID = new SelectList(db.CheckIns, "CheckInID", "CheckInID", checkOut.CheckInID);
            ViewBag.RoomNum = new SelectList(db.Rooms, "RoomNum", "RoomInfo", checkOut.RoomNum);
            ViewBag.customerID = new SelectList(db.Customers, "CustomerID", "Name", checkOut.customerID);
            return View(checkOut);
        }

        // GET: CheckOuts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckOut checkOut = db.CheckOuts.Find(id);
            if (checkOut == null)
            {
                return HttpNotFound();
            }
            ViewBag.CheckInID = new SelectList(db.CheckIns, "CheckInID", "CheckInID", checkOut.CheckInID);
            ViewBag.RoomNum = new SelectList(db.Rooms, "RoomNum", "RoomInfo", checkOut.RoomNum);
            ViewBag.customerID = new SelectList(db.Customers, "CustomerID", "Name", checkOut.customerID);
            return View(checkOut);
        }

        // POST: CheckOuts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CheckOutID,CheckOutDate,CheckInID,RoomNum,customerID,noadults,nochild,passportnum")] CheckOut checkOut)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkOut).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CheckInID = new SelectList(db.CheckIns, "CheckInID", "CheckInID", checkOut.CheckInID);
            ViewBag.RoomNum = new SelectList(db.Rooms, "RoomNum", "RoomInfo", checkOut.RoomNum);
            ViewBag.customerID = new SelectList(db.Customers, "CustomerID", "Name", checkOut.customerID);
            return View(checkOut);
        }

        // GET: CheckOuts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckOut checkOut = db.CheckOuts.Find(id);
            if (checkOut == null)
            {
                return HttpNotFound();
            }
            return View(checkOut);
        }

        // POST: CheckOuts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CheckOut checkOut = db.CheckOuts.Find(id);
            db.CheckOuts.Remove(checkOut);
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
