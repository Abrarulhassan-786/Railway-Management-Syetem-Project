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
    public class tbl_TicketController : Controller
    {
        private DB_RMSEntities db = new DB_RMSEntities();

        // GET: tbl_Ticket
        public ActionResult Index()
        {
            var tbl_Ticket = db.tbl_Ticket.Include(t => t.tbl_Passenger).Include(t => t.tbl_Station).Include(t => t.tbl_User);
            return View(tbl_Ticket.ToList());
        }

        // GET: tbl_Ticket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Ticket tbl_Ticket = db.tbl_Ticket.Find(id);
            if (tbl_Ticket == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Ticket);
        }

        // GET: tbl_Ticket/Create
        public ActionResult Create()
        {
            ViewBag.P_ID = new SelectList(db.tbl_Passenger, "P_ID", "p_Name");
            ViewBag.S_No = new SelectList(db.tbl_Station, "S_No", "S_Name");
            ViewBag.U_Id = new SelectList(db.tbl_User, "U_Id", "U_Fname");
            return View();
        }

        // POST: tbl_Ticket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "t_ID,t_BookedUser,t_PassengrNo,t_Payment,P_ID,U_Id,S_No")] tbl_Ticket tbl_Ticket)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Ticket.Add(tbl_Ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.P_ID = new SelectList(db.tbl_Passenger, "P_ID", "p_Name", tbl_Ticket.P_ID);
            ViewBag.S_No = new SelectList(db.tbl_Station, "S_No", "S_Name", tbl_Ticket.S_No);
            ViewBag.U_Id = new SelectList(db.tbl_User, "U_Id", "U_Fname", tbl_Ticket.U_Id);
            return View(tbl_Ticket);
        }

        // GET: tbl_Ticket/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Ticket tbl_Ticket = db.tbl_Ticket.Find(id);
            if (tbl_Ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.P_ID = new SelectList(db.tbl_Passenger, "P_ID", "p_Name", tbl_Ticket.P_ID);
            ViewBag.S_No = new SelectList(db.tbl_Station, "S_No", "S_Name", tbl_Ticket.S_No);
            ViewBag.U_Id = new SelectList(db.tbl_User, "U_Id", "U_Fname", tbl_Ticket.U_Id);
            return View(tbl_Ticket);
        }

        // POST: tbl_Ticket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "t_ID,t_BookedUser,t_PassengrNo,t_Payment,P_ID,U_Id,S_No")] tbl_Ticket tbl_Ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.P_ID = new SelectList(db.tbl_Passenger, "P_ID", "p_Name", tbl_Ticket.P_ID);
            ViewBag.S_No = new SelectList(db.tbl_Station, "S_No", "S_Name", tbl_Ticket.S_No);
            ViewBag.U_Id = new SelectList(db.tbl_User, "U_Id", "U_Fname", tbl_Ticket.U_Id);
            return View(tbl_Ticket);
        }

        // GET: tbl_Ticket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Ticket tbl_Ticket = db.tbl_Ticket.Find(id);
            if (tbl_Ticket == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Ticket);
        }

        // POST: tbl_Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Ticket tbl_Ticket = db.tbl_Ticket.Find(id);
            db.tbl_Ticket.Remove(tbl_Ticket);
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
