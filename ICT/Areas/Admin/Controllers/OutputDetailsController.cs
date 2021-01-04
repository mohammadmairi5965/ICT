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
    public class OutputDetailsController : Controller
    {
        private SoftwareReportEntities db = new SoftwareReportEntities();

        // GET: Admin/OutputDetails
        public ActionResult Index()
        {
            var outputDetail = db.OutputDetail.Include(o => o.Hardware).Include(o => o.Output);
            return View(outputDetail.ToList());
        }

        // GET: Admin/OutputDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutputDetail outputDetail = db.OutputDetail.Find(id);
            if (outputDetail == null)
            {
                return HttpNotFound();
            }
            return View(outputDetail);
        }

        // GET: Admin/OutputDetails/Create
        public ActionResult Create()
        {
            ViewBag.HardwareID = new SelectList(db.Hardware, "ID", "Name");
            ViewBag.OutputID = new SelectList(db.Output, "OutputID", "Description");
            return View();
        }

        // POST: Admin/OutputDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OutputDetailID,HardwareID,Tedad,OutputID")] OutputDetail outputDetail)
        {
            if (ModelState.IsValid)
            {
                db.OutputDetail.Add(outputDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HardwareID = new SelectList(db.Hardware, "ID", "Name", outputDetail.HardwareID);
            ViewBag.OutputID = new SelectList(db.Output, "OutputID", "Description", outputDetail.OutputID);
            return View(outputDetail);
        }

        // GET: Admin/OutputDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutputDetail outputDetail = db.OutputDetail.Find(id);
            if (outputDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.HardwareID = new SelectList(db.Hardware, "ID", "Name", outputDetail.HardwareID);
            ViewBag.OutputID = new SelectList(db.Output, "OutputID", "Description", outputDetail.OutputID);
            return View(outputDetail);
        }

        // POST: Admin/OutputDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OutputDetailID,HardwareID,Tedad,OutputID")] OutputDetail outputDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outputDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HardwareID = new SelectList(db.Hardware, "ID", "Name", outputDetail.HardwareID);
            ViewBag.OutputID = new SelectList(db.Output, "OutputID", "Description", outputDetail.OutputID);
            return View(outputDetail);
        }

        // GET: Admin/OutputDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutputDetail outputDetail = db.OutputDetail.Find(id);
            if (outputDetail == null)
            {
                return HttpNotFound();
            }
            return View(outputDetail);
        }

        // POST: Admin/OutputDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OutputDetail outputDetail = db.OutputDetail.Find(id);
           

            try
            {
                db.OutputDetail.Remove(outputDetail);
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
