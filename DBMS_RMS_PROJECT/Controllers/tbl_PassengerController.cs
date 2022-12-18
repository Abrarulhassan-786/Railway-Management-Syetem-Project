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
    public class tbl_PassengerController : Controller
    {
        private DB_RMSEntities db = new DB_RMSEntities();

        // GET: tbl_Passenger
        public ActionResult Index()
        {
            var tbl_Passenger = db.tbl_Passenger.Include(t => t.tbl_Train);
            return View(tbl_Passenger.ToList());
        }

        // GET: tbl_Passenger/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Passenger tbl_Passenger = db.tbl_Passenger.Find(id);
            if (tbl_Passenger == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Passenger);
        }

        // GET: tbl_Passenger/Create
        public ActionResult Create()
        {
            ViewBag.Train_No = new SelectList(db.tbl_Train, "Train_No", "T_Name");
            return View();
        }

        // POST: tbl_Passenger/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "P_ID,p_Name,p_Phone_No,P_Age,P_Seat_number,P_Gender,Train_No")] tbl_Passenger tbl_Passenger)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Passenger.Add(tbl_Passenger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Train_No = new SelectList(db.tbl_Train, "Train_No", "T_Name", tbl_Passenger.Train_No);
            return View(tbl_Passenger);
        }

        // GET: tbl_Passenger/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Passenger tbl_Passenger = db.tbl_Passenger.Find(id);
            if (tbl_Passenger == null)
            {
                return HttpNotFound();
            }
            ViewBag.Train_No = new SelectList(db.tbl_Train, "Train_No", "T_Name", tbl_Passenger.Train_No);
            return View(tbl_Passenger);
        }

        // POST: tbl_Passenger/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "P_ID,p_Name,p_Phone_No,P_Age,P_Seat_number,P_Gender,Train_No")] tbl_Passenger tbl_Passenger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Passenger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Train_No = new SelectList(db.tbl_Train, "Train_No", "T_Name", tbl_Passenger.Train_No);
            return View(tbl_Passenger);
        }

        // GET: tbl_Passenger/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Passenger tbl_Passenger = db.tbl_Passenger.Find(id);
            if (tbl_Passenger == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Passenger);
        }

        // POST: tbl_Passenger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Passenger tbl_Passenger = db.tbl_Passenger.Find(id);
            db.tbl_Passenger.Remove(tbl_Passenger);
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
