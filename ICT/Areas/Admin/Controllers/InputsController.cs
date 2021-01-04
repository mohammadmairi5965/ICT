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
    public class InputsController : Controller
    {
        private SoftwareReportEntities db = new SoftwareReportEntities();

        // GET: Admin/Inputs
        public ActionResult Index()
        {
            var input = db.Input.Include(i => i.User);
            return View(input.ToList());
        }

        // GET: Admin/Inputs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Input input = db.Input.Find(id);
            if (input == null)
            {
                return HttpNotFound();
            }
            return View(input);
        }

        // GET: Admin/Inputs/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.User, "userID", "UserName");
            return View();
        }

        // POST: Admin/Inputs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InputID,FactorNo,UserID,Description,InputDate")] Input input)
        {
            if (ModelState.IsValid)
            {
                db.Input.Add(input);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.User, "userID", "UserName", input.UserID);
            return View(input);
        }

        // GET: Admin/Inputs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Input input = db.Input.Find(id);
            if (input == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.User, "userID", "UserName", input.UserID);
            return View(input);
        }

        // POST: Admin/Inputs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InputID,FactorNo,UserID,Description,InputDate")] Input input)
        {
            if (ModelState.IsValid)
            {
                db.Entry(input).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.User, "userID", "UserName", input.UserID);
            return View(input);
        }

        // GET: Admin/Inputs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Input input = db.Input.Find(id);
            if (input == null)
            {
                return HttpNotFound();
            }
            return View(input);
        }

        // POST: Admin/Inputs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Input input = db.Input.Find(id);
           
            try
            {
                db.Input.Remove(input);
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
