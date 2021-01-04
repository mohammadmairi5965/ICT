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
    public class ComputerTypesController : Controller
    {
        private SoftwareReportEntities db = new SoftwareReportEntities();

        // GET: Admin/ComputerTypes
        public ActionResult Index()
        {
            return View(db.ComputerType.ToList());
        }

        // GET: Admin/ComputerTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerType computerType = db.ComputerType.Find(id);
            if (computerType == null)
            {
                return HttpNotFound();
            }
            return View(computerType);
        }

        // GET: Admin/ComputerTypes/Create
        public ActionResult Create()
        {
            ViewBag.SubUnitID = new SelectList(db.SubUnit, "ID", "Title");
            return View();
        }

        // POST: Admin/ComputerTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,SubUnitID")] ComputerType computerType)
        {
            if (ModelState.IsValid)
            {
                db.ComputerType.Add(computerType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(computerType);
        }

        // GET: Admin/ComputerTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerType computerType = db.ComputerType.Find(id);
            if (computerType == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubUnitID = new SelectList(db.SubUnit, "ID", "Title",computerType.SubUnitID);
            return View(computerType);
        }

        // POST: Admin/ComputerTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,SubUnitID")] ComputerType computerType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(computerType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(computerType);
        }

        // GET: Admin/ComputerTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerType computerType = db.ComputerType.Find(id);
            if (computerType == null)
            {
                return HttpNotFound();
            }
            return View(computerType);
        }

        // POST: Admin/ComputerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComputerType computerType = db.ComputerType.Find(id);
           
            try
            {
                db.ComputerType.Remove(computerType);
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
