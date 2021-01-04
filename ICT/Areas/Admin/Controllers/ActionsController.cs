using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using Action = DataLayer.Action;

namespace ICT.Areas.Admin.Controllers
{
   // [Authorize(Roles = ("admin"))]
    public class ActionsController : Controller
    {
        private SoftwareReportEntities db = new SoftwareReportEntities();

        // GET: Admin/Actions
        public ActionResult Index()
        {
            
            return View(db.Action.ToList());
        }

        // GET: Admin/Actions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Action action = db.Action.Find(id);
            if (action == null)
            {
                return HttpNotFound();
            }
            return View(action);
        }

        // GET: Admin/Actions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Actions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActionID,Title")] Action action1)
        {
            if (ModelState.IsValid)
            {
                db.Action.Add(action1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(action1);
        }

        // GET: Admin/Actions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Action action = db.Action.Find(id);
            if (action == null)
            {
                return HttpNotFound();
            }
            return View(action);
        }

        // POST: Admin/Actions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActionID,Title")] Action action)
        {
            if (ModelState.IsValid)
            {
                db.Entry(action).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(action);
        }

        // GET: Admin/Actions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Action action = db.Action.Find(id);
            if (action == null)
            {
                return HttpNotFound();
            }
            return View(action);
        }

        // POST: Admin/Actions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Action action = db.Action.Find(id);
            //db.Action.Remove(action);
            //db.SaveChanges();
            //return RedirectToAction("Index");


            try
            {
                db.Action.Remove(action);
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
