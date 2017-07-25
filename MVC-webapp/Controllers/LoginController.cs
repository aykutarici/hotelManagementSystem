using MVC_webapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_webapp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            Session["logeduserID"] = null;
            Session["logedusername"] = null;
            Session["admin"] = null;
            return View();

        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult reacherror()
        {

            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User u)
        {
            if (ModelState.IsValid)
            {
                using (MVC_HotelProject2Entities dc = new MVC_HotelProject2Entities())
                {
                    var v = dc.Users.Where(a => a.Name.Equals(u.Name) && a.Password.Equals(u.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["logeduserID"] = v.ID.ToString();
                        Session["logedusername"] = v.Name.ToString();
                        Session["admin"] = v.ID.ToString();
                        return RedirectToAction("afterlogin");
                    }

                }
            }
            return View();
        }
        public ActionResult afterlogin(User u)
        {


            return View();
        }
    }
}
