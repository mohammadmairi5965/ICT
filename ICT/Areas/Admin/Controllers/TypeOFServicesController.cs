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
    public class TypeOFServicesController : Controller
    {
        private SoftwareReportEntities db = new SoftwareReportEntities();

        // GET: Admin/TypeOFServices
        public ActionResult Index()
        {
            return View(db.TypeOFService.ToList());
        }

        // GET: Admin/TypeOFServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOFService typeOFService = db.TypeOFService.Find(id);
            if (typeOFService == null)
            {
                return HttpNotFound();
            }
            return View(typeOFService);
        }

        // GET: Admin/TypeOFServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TypeOFServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title")] TypeOFService typeOFService)
        {
            if (ModelState.IsValid)
            {
                db.TypeOFService.Add(typeOFService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeOFService);
        }

        // GET: Admin/TypeOFServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOFService typeOFService = db.TypeOFService.Find(id);
            if (typeOFService == null)
            {
                return HttpNotFound();
            }
            return View(typeOFService);
        }

        // POST: Admin/TypeOFServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title")] TypeOFService typeOFService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeOFService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeOFService);
        }

        // GET: Admin/TypeOFServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOFService typeOFService = db.TypeOFService.Find(id);
            if (typeOFService == null)
            {
                return HttpNotFound();
            }
            return View(typeOFService);
        }

        // POST: Admin/TypeOFServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeOFService typeOFService = db.TypeOFService.Find(id);
          
            try
            {
                db.TypeOFService.Remove(typeOFService);
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
