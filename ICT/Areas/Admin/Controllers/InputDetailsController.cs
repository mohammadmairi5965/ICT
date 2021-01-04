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
    public class InputDetailsController : Controller
    {
        private SoftwareReportEntities db = new SoftwareReportEntities();

        // GET: Admin/InputDetails
        public ActionResult Index()
        {
            var inputDetail = db.InputDetail.Include(i => i.Hardware).Include(i => i.Input);
            return View(inputDetail.ToList());
        }

        // GET: Admin/InputDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InputDetail inputDetail = db.InputDetail.Find(id);
            if (inputDetail == null)
            {
                return HttpNotFound();
            }
            return View(inputDetail);
        }

        // GET: Admin/InputDetails/Create
        public ActionResult Create()
        {
            ViewBag.HardwareID = new SelectList(db.Hardware, "ID", "Name");
            ViewBag.InputID = new SelectList(db.Input, "InputID", "FactorNo");
            return View();
        }

        // POST: Admin/InputDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InputDetailID,InputID,HardwareID,Tedad")] InputDetail inputDetail)
        {
            if (ModelState.IsValid)
            {
                db.InputDetail.Add(inputDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HardwareID = new SelectList(db.Hardware, "ID", "Name", inputDetail.HardwareID);
            ViewBag.InputID = new SelectList(db.Input, "InputID", "FactorNo", inputDetail.InputID);
            return View(inputDetail);
        }

        // GET: Admin/InputDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InputDetail inputDetail = db.InputDetail.Find(id);
            if (inputDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.HardwareID = new SelectList(db.Hardware, "ID", "Name", inputDetail.HardwareID);
            ViewBag.InputID = new SelectList(db.Input, "InputID", "FactorNo", inputDetail.InputID);
            return View(inputDetail);
        }

        // POST: Admin/InputDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InputDetailID,InputID,HardwareID,Tedad")] InputDetail inputDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inputDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HardwareID = new SelectList(db.Hardware, "ID", "Name", inputDetail.HardwareID);
            ViewBag.InputID = new SelectList(db.Input, "InputID", "FactorNo", inputDetail.InputID);
            return View(inputDetail);
        }

        // GET: Admin/InputDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InputDetail inputDetail = db.InputDetail.Find(id);
            if (inputDetail == null)
            {
                return HttpNotFound();
            }
            return View(inputDetail);
        }

        // POST: Admin/InputDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InputDetail inputDetail = db.InputDetail.Find(id);
          
            try
            {
                db.InputDetail.Remove(inputDetail);
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
