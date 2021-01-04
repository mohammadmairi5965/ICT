using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ICT.Areas.Admin.Controllers
{
    public class PeriodicVisitsController : Controller
    {
        private SoftwareReportEntities db = new SoftwareReportEntities();

        // GET: Admin/PeriodicVisits
        public ActionResult Index()
        {
            return View(db.PeriodicVisits.ToList());
        }

        // GET: Admin/PeriodicVisits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeriodicVisits periodicVisits = db.PeriodicVisits.Find(id);
            if (periodicVisits == null)
            {
                return HttpNotFound();
            }
            return View(periodicVisits);
        }

        // GET: Admin/PeriodicVisits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PeriodicVisits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StartDate,Title,Description")] PeriodicVisits periodicVisits)
        {
            if (ModelState.IsValid)
            {
                db.PeriodicVisits.Add(periodicVisits);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(periodicVisits);
        }

        // GET: Admin/PeriodicVisits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeriodicVisits periodicVisits = db.PeriodicVisits.Find(id);
            if (periodicVisits == null)
            {
                return HttpNotFound();
            }
            return View(periodicVisits);
        }

        // POST: Admin/PeriodicVisits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StartDate,Title,Description")] PeriodicVisits periodicVisits)
        {
            if (ModelState.IsValid)
            {
                db.Entry(periodicVisits).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(periodicVisits);
        }

        // GET: Admin/PeriodicVisits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeriodicVisits periodicVisits = db.PeriodicVisits.Find(id);
            if (periodicVisits == null)
            {
                return HttpNotFound();
            }
            return View(periodicVisits);
        }

        // POST: Admin/PeriodicVisits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PeriodicVisits periodicVisits = db.PeriodicVisits.Find(id);
          
            try
            {
                db.PeriodicVisits.Remove(periodicVisits);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.Error = true;
                return View("Delete");
            }
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
