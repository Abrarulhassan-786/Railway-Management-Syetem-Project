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
    public class tbl_Ticket_CategoryController : Controller
    {
        private DB_RMSEntities db = new DB_RMSEntities();

        // GET: tbl_Ticket_Category
        public ActionResult Index()
        {
            var tbl_Ticket_Category = db.tbl_Ticket_Category.Include(t => t.tbl_Ticket);
            return View(tbl_Ticket_Category.ToList());
        }

        // GET: tbl_Ticket_Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Ticket_Category tbl_Ticket_Category = db.tbl_Ticket_Category.Find(id);
            if (tbl_Ticket_Category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Ticket_Category);
        }

        // GET: tbl_Ticket_Category/Create
        public ActionResult Create()
        {
            ViewBag.t_ID = new SelectList(db.tbl_Ticket, "t_ID", "t_ID");
            return View();
        }

        // POST: tbl_Ticket_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tc_id,tc_Gernal,tc_Businsman,tc_parliment,tc_Economy,t_ID")] tbl_Ticket_Category tbl_Ticket_Category)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Ticket_Category.Add(tbl_Ticket_Category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.t_ID = new SelectList(db.tbl_Ticket, "t_ID", "t_ID", tbl_Ticket_Category.t_ID);
            return View(tbl_Ticket_Category);
        }

        // GET: tbl_Ticket_Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Ticket_Category tbl_Ticket_Category = db.tbl_Ticket_Category.Find(id);
            if (tbl_Ticket_Category == null)
            {
                return HttpNotFound();
            }
            ViewBag.t_ID = new SelectList(db.tbl_Ticket, "t_ID", "t_ID", tbl_Ticket_Category.t_ID);
            return View(tbl_Ticket_Category);
        }

        // POST: tbl_Ticket_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tc_id,tc_Gernal,tc_Businsman,tc_parliment,tc_Economy,t_ID")] tbl_Ticket_Category tbl_Ticket_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Ticket_Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.t_ID = new SelectList(db.tbl_Ticket, "t_ID", "t_ID", tbl_Ticket_Category.t_ID);
            return View(tbl_Ticket_Category);
        }

        // GET: tbl_Ticket_Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Ticket_Category tbl_Ticket_Category = db.tbl_Ticket_Category.Find(id);
            if (tbl_Ticket_Category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Ticket_Category);
        }

        // POST: tbl_Ticket_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Ticket_Category tbl_Ticket_Category = db.tbl_Ticket_Category.Find(id);
            db.tbl_Ticket_Category.Remove(tbl_Ticket_Category);
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
