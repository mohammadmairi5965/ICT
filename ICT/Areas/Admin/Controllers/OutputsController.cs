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
    public class OutputsController : Controller
    {
        private SoftwareReportEntities db = new SoftwareReportEntities();

        // GET: Admin/Outputs
        public ActionResult Index()
        {
            return View(db.Output.ToList());
        }

        // GET: Admin/Outputs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Output output = db.Output.Find(id);
            if (output == null)
            {
                return HttpNotFound();
            }
            return View(output);
        }

        // GET: Admin/Outputs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Outputs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OutputID,UserID,Description,InputDate")] Output output)
        {
            if (ModelState.IsValid)
            {
                db.Output.Add(output);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(output);
        }

        // GET: Admin/Outputs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Output output = db.Output.Find(id);
            if (output == null)
            {
                return HttpNotFound();
            }
            return View(output);
        }

        // POST: Admin/Outputs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OutputID,UserID,Description,InputDate")] Output output)
        {
            if (ModelState.IsValid)
            {
                db.Entry(output).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(output);
        }

        // GET: Admin/Outputs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Output output = db.Output.Find(id);
            if (output == null)
            {
                return HttpNotFound();
            }
            return View(output);
        }

        // POST: Admin/Outputs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Output output = db.Output.Find(id);
           
            try
            {
                db.Output.Remove(output);
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
