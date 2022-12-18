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
    public class tbl_TrainController : Controller
    {
        private DB_RMSEntities db = new DB_RMSEntities();

        // GET: tbl_Train
        public ActionResult Index()
        {
            return View(db.tbl_Train.ToList());
        }

        // GET: tbl_Train/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Train tbl_Train = db.tbl_Train.Find(id);
            if (tbl_Train == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Train);
        }

        // GET: tbl_Train/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_Train/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Train_No,T_Name,T_Desination,T_DepartureTime,T_ArrivalTime,T_seats_Available")] tbl_Train tbl_Train)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Train.Add(tbl_Train);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Train);
        }

        // GET: tbl_Train/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Train tbl_Train = db.tbl_Train.Find(id);
            if (tbl_Train == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Train);
        }

        // POST: tbl_Train/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Train_No,T_Name,T_Desination,T_DepartureTime,T_ArrivalTime,T_seats_Available")] tbl_Train tbl_Train)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Train).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Train);
        }

        // GET: tbl_Train/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Train tbl_Train = db.tbl_Train.Find(id);
            if (tbl_Train == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Train);
        }

        // POST: tbl_Train/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Train tbl_Train = db.tbl_Train.Find(id);
            db.tbl_Train.Remove(tbl_Train);
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
