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
    public class OrdersController : BaseController
    {
        private MVC_HotelProject2Entities db = new MVC_HotelProject2Entities();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Laundry).Include(o => o.RentCar).Include(o => o.Room);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return PartialView(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.LoundryID = new SelectList(db.Laundries, "LoundryID", "ServiceName");
            ViewBag.CarID = new SelectList(db.RentCars, "CarID", "CarBrand");
            ViewBag.RoomNum = new SelectList(db.Rooms, "RoomNum", "RoomInfo");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,ServiceID,RoomNum,ServicePrice,FirstDay,LastDay,Quantity,OrderPrice,CarID,LoundryID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoundryID = new SelectList(db.Laundries, "LoundryID", "ServiceName", order.LoundryID);
            ViewBag.CarID = new SelectList(db.RentCars, "CarID", "CarBrand", order.CarID);
            ViewBag.RoomNum = new SelectList(db.Rooms, "RoomNum", "RoomInfo", order.RoomNum);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoundryID = new SelectList(db.Laundries, "LoundryID", "ServiceName", order.LoundryID);
            ViewBag.CarID = new SelectList(db.RentCars, "CarID", "CarBrand", order.CarID);
            ViewBag.RoomNum = new SelectList(db.Rooms, "RoomNum", "RoomInfo", order.RoomNum);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,ServiceID,RoomNum,ServicePrice,FirstDay,LastDay,Quantity,OrderPrice,CarID,LoundryID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoundryID = new SelectList(db.Laundries, "LoundryID", "ServiceName", order.LoundryID);
            ViewBag.CarID = new SelectList(db.RentCars, "CarID", "CarBrand", order.CarID);
            ViewBag.RoomNum = new SelectList(db.Rooms, "RoomNum", "RoomInfo", order.RoomNum);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
