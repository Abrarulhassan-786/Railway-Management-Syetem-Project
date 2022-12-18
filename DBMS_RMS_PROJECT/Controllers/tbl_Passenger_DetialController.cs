using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBMS_RMS_PROJECT.Models;

namespace DBMS_RMS_PROJECT.Controllers
{
    public class tbl_Passenger_DetialController : Controller
    {
        private DB_RMSEntities db = new DB_RMSEntities();

        // GET: tbl_Passenger_Detial
        public ActionResult Index()
        {
            var tbl_Passenger_Detial = db.tbl_Passenger_Detial.Include(t => t.tbl_Passenger);
            return View(tbl_Passenger_Detial.ToList());
        }

        // GET: tbl_Passenger_Detial/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Passenger_Detial tbl_Passenger_Detial = db.tbl_Passenger_Detial.Find(id);
            if (tbl_Passenger_Detial == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Passenger_Detial);
        }

        // GET: tbl_Passenger_Detial/Create
        public ActionResult Create()
        {
            ViewBag.P_ID = new SelectList(db.tbl_Passenger, "P_ID", "p_Name");
            return View();
        }

        // POST: tbl_Passenger_Detial/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pd_id,pd_name,pd_Age,pd_Email,P_ID")] tbl_Passenger_Detial tbl_Passenger_Detial)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Passenger_Detial.Add(tbl_Passenger_Detial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.P_ID = new SelectList(db.tbl_Passenger, "P_ID", "p_Name", tbl_Passenger_Detial.P_ID);
            return View(tbl_Passenger_Detial);
        }

        // GET: tbl_Passenger_Detial/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Passenger_Detial tbl_Passenger_Detial = db.tbl_Passenger_Detial.Find(id);
            if (tbl_Passenger_Detial == null)
            {
                return HttpNotFound();
            }
            ViewBag.P_ID = new SelectList(db.tbl_Passenger, "P_ID", "p_Name", tbl_Passenger_Detial.P_ID);
            return View(tbl_Passenger_Detial);
        }

        // POST: tbl_Passenger_Detial/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pd_id,pd_name,pd_Age,pd_Email,P_ID")] tbl_Passenger_Detial tbl_Passenger_Detial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Passenger_Detial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.P_ID = new SelectList(db.tbl_Passenger, "P_ID", "p_Name", tbl_Passenger_Detial.P_ID);
            return View(tbl_Passenger_Detial);
        }

        // GET: tbl_Passenger_Detial/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Passenger_Detial tbl_Passenger_Detial = db.tbl_Passenger_Detial.Find(id);
            if (tbl_Passenger_Detial == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Passenger_Detial);
        }

        // POST: tbl_Passenger_Detial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Passenger_Detial tbl_Passenger_Detial = db.tbl_Passenger_Detial.Find(id);
            db.tbl_Passenger_Detial.Remove(tbl_Passenger_Detial);
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
