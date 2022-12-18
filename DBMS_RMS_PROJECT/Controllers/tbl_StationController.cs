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
    public class tbl_StationController : Controller
    {
        private DB_RMSEntities db = new DB_RMSEntities();

        // GET: tbl_Station
        public ActionResult Index()
        {
            var tbl_Station = db.tbl_Station.Include(t => t.tbl_Train).Include(t => t.tbl_User);
            return View(tbl_Station.ToList());
        }

        // GET: tbl_Station/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Station tbl_Station = db.tbl_Station.Find(id);
            if (tbl_Station == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Station);
        }

        // GET: tbl_Station/Create
        public ActionResult Create()
        {
            ViewBag.Train_No = new SelectList(db.tbl_Train, "Train_No", "T_Name");
            ViewBag.U_Id = new SelectList(db.tbl_User, "U_Id", "U_Fname");
            return View();
        }

        // POST: tbl_Station/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "S_No,S_Name,S_ArrivalTime,U_Id,Train_No")] tbl_Station tbl_Station)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Station.Add(tbl_Station);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Train_No = new SelectList(db.tbl_Train, "Train_No", "T_Name", tbl_Station.Train_No);
            ViewBag.U_Id = new SelectList(db.tbl_User, "U_Id", "U_Fname", tbl_Station.U_Id);
            return View(tbl_Station);
        }

        // GET: tbl_Station/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Station tbl_Station = db.tbl_Station.Find(id);
            if (tbl_Station == null)
            {
                return HttpNotFound();
            }
            ViewBag.Train_No = new SelectList(db.tbl_Train, "Train_No", "T_Name", tbl_Station.Train_No);
            ViewBag.U_Id = new SelectList(db.tbl_User, "U_Id", "U_Fname", tbl_Station.U_Id);
            return View(tbl_Station);
        }

        // POST: tbl_Station/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "S_No,S_Name,S_ArrivalTime,U_Id,Train_No")] tbl_Station tbl_Station)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Station).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Train_No = new SelectList(db.tbl_Train, "Train_No", "T_Name", tbl_Station.Train_No);
            ViewBag.U_Id = new SelectList(db.tbl_User, "U_Id", "U_Fname", tbl_Station.U_Id);
            return View(tbl_Station);
        }

        // GET: tbl_Station/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Station tbl_Station = db.tbl_Station.Find(id);
            if (tbl_Station == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Station);
        }

        // POST: tbl_Station/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Station tbl_Station = db.tbl_Station.Find(id);
            db.tbl_Station.Remove(tbl_Station);
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
