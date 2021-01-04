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
    public class HardwareTypesController : Controller
    {
        private SoftwareReportEntities db = new SoftwareReportEntities();

        // GET: Admin/HardwareTypes
        public ActionResult Index()
        {
            return View(db.HardwareType.ToList());
        }

        // GET: Admin/HardwareTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HardwareType hardwareType = db.HardwareType.Find(id);
            if (hardwareType == null)
            {
                return HttpNotFound();
            }
            return View(hardwareType);
        }

        // GET: Admin/HardwareTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/HardwareTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HardwareTypeID,Name,SubArea")] HardwareType hardwareType)
        {
            if (ModelState.IsValid)
            {
                db.HardwareType.Add(hardwareType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hardwareType);
        }

        // GET: Admin/HardwareTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HardwareType hardwareType = db.HardwareType.Find(id);
            if (hardwareType == null)
            {
                return HttpNotFound();
            }
            return View(hardwareType);
        }

        // POST: Admin/HardwareTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HardwareTypeID,Name,SubArea")] HardwareType hardwareType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hardwareType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hardwareType);
        }

        // GET: Admin/HardwareTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HardwareType hardwareType = db.HardwareType.Find(id);
            if (hardwareType == null)
            {
                return HttpNotFound();
            }
            return View(hardwareType);
        }

        // POST: Admin/HardwareTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HardwareType hardwareType = db.HardwareType.Find(id);
         
            try
            {
                db.HardwareType.Remove(hardwareType);
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
