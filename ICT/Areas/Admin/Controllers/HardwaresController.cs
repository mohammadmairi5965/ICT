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
    public class HardwaresController : Controller
    {
        private SoftwareReportEntities db = new SoftwareReportEntities();

        // GET: Admin/Hardwares
        public ActionResult Index()
        {
            var hardware = db.Hardware.Include(h => h.HardwareType);
            return View(hardware.ToList());
        }

        // GET: Admin/Hardwares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hardware hardware = db.Hardware.Find(id);
            if (hardware == null)
            {
                return HttpNotFound();
            }
            return View(hardware);
        }

        // GET: Admin/Hardwares/Create
        public ActionResult Create()
        {
            ViewBag.Type = new SelectList(db.HardwareType, "HardwareTypeID", "Name");
            return View();
        }

        // POST: Admin/Hardwares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Type")] Hardware hardware)
        {
            if (ModelState.IsValid)
            {
                db.Hardware.Add(hardware);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Type = new SelectList(db.HardwareType, "HardwareTypeID", "Name", hardware.Type);
            return View(hardware);
        }

        // GET: Admin/Hardwares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hardware hardware = db.Hardware.Find(id);
            if (hardware == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type = new SelectList(db.HardwareType, "HardwareTypeID", "Name", hardware.Type);
            return View(hardware);
        }

        // POST: Admin/Hardwares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Type")] Hardware hardware)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hardware).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Type = new SelectList(db.HardwareType, "HardwareTypeID", "Name", hardware.Type);
            return View(hardware);
        }

        // GET: Admin/Hardwares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hardware hardware = db.Hardware.Find(id);
            if (hardware == null)
            {
                return HttpNotFound();
            }
            return View(hardware);
        }

        // POST: Admin/Hardwares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hardware hardware = db.Hardware.Find(id);
         
            try
            {
                db.Hardware.Remove(hardware);
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
