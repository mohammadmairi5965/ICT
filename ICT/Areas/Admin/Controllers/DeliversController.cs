using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using Utilities;

namespace ICT.Areas.Admin.Controllers
{
    public class DeliversController : Controller
    {
        private SoftwareReportEntities db = new SoftwareReportEntities();

        // GET: Admin/Delivers
        public ActionResult Index()
        {
            var com = db.Computer.Select(c => c.Computer_ID).Except(db.Deliver.Where(c => c.ReturnDate == null).Select(c => c.ComputerID)).ToList();
            if (com.Count == 0)
            {
                ViewBag.error = true;
            }
            else ViewBag.error = false;
            var deliver = db.Deliver.Include(d => d.Computer).Include(d => d.User);
            return View(deliver.ToList());
        }
        // GET: Admin/Delivers
        public ActionResult direct(String comID)
        {
            var dlv = db.Deliver.Where(c => c.ComputerID == comID && c.ReturnDate == null).ToList();
            if (dlv.Count == 0)
            {
                return RedirectToAction("Create", new { comID = comID });
            }
            else
            {
                return RedirectToAction("ReturnCom", new { id = dlv.FirstOrDefault().id });
            }

        }

        // GET: Admin/Delivers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deliver deliver = db.Deliver.Find(id);
            if (deliver == null)
            {
                return HttpNotFound();
            }
            return View(deliver);
        }
        // GET: Admin/Delivers/Edit/5
        public ActionResult ReturnCom(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Deliver deliver = db.Deliver.Find(id);
            if (deliver == null)
            {
                ViewBag.errorreturn = true;
                return RedirectToAction("Index");
            }
            ViewBag.ComputerID = new SelectList(db.Computer, "Computer_ID", "Computer_ID", deliver.ComputerID);
            ViewBag.UserID = new SelectList(db.User, "userID", "UserName", deliver.UserID);
            return View(deliver);
        }

        // POST: Admin/Delivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReturnCom([Bind(Include = "id,ComputerID,UserID,ComputerName,DeliveryDate,ReturnDate")] Deliver deliver)
        {
            if (ModelState.IsValid && deliver.DeliveryDate < deliver.ReturnDate)
            {
                deliver.ReturnDate = deliver.ReturnDate == null ? deliver.ReturnDate : DateConvertor.ToMiladi((DateTime)deliver.ReturnDate);
                deliver.DeliveryDate = DateConvertor.ToMiladi((DateTime)deliver.DeliveryDate);
                db.Entry(deliver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (deliver.DeliveryDate >= deliver.ReturnDate)
            {
                ViewBag.error = true;
            }
            ViewBag.ComputerID = new SelectList(db.Computer, "Computer_ID", "Computer_ID", deliver.ComputerID);
            ViewBag.UserID = new SelectList(db.User, "userID", "UserName", deliver.UserID);
            return View(deliver);
        }
        // GET: Admin/Delivers/Create
        public ActionResult Create(String comID)
        {
            var com = db.Computer.Select(c => c.Computer_ID).Except(db.Deliver.Where(c => c.ReturnDate == null).Select(c => c.ComputerID)).ToList();
            if (com.Count == 0)
            {
                ViewBag.error = true;
                return RedirectToAction("Index");
            }
            if (comID == null)
            {
                ViewBag.ComputerID = new SelectList(com);
            }
            else
            {
                ViewBag.ComputerID = new SelectList(com, comID);
            }
            ViewBag.UserID = new SelectList(db.User, "userID", "UserName");
            return View();
        }

        // POST: Admin/Delivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ComputerID,UserID,ComputerName,DeliveryDate,ReturnDate")] Deliver deliver)
        {
            var lastDeliver= db.Deliver.Where(c => c.ComputerID == deliver.ComputerID).Max(c => c.ReturnDate);
            if (ModelState.IsValid )
            {
                if (lastDeliver==null || lastDeliver< DateConvertor.ToMiladi(deliver.DeliveryDate))
                {
                    deliver.DeliveryDate = DateConvertor.ToMiladi(deliver.DeliveryDate);
                    db.Deliver.Add(deliver);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            if (lastDeliver > DateConvertor.ToMiladi(deliver.DeliveryDate))
            {
                ViewBag.error = true;
            }
            ViewBag.ComputerID = new SelectList(db.Computer, "Computer_ID", "Computer_ID", deliver.ComputerID);
            ViewBag.UserID = new SelectList(db.User, "userID", "UserName", deliver.UserID);
            return View(deliver);
        }

        // GET: Admin/Delivers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deliver deliver = db.Deliver.Find(id);
            if (deliver == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComputerID = new SelectList(db.Computer, "Computer_ID", "Computer_ID", deliver.ComputerID);
            ViewBag.UserID = new SelectList(db.User, "userID", "UserName", deliver.UserID);
            return View(deliver);
        }

        // POST: Admin/Delivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ComputerID,UserID,ComputerName,DeliveryDate,ReturnDate")] Deliver deliver)
        {
            if (ModelState.IsValid && deliver.DeliveryDate < deliver.ReturnDate)
            {
                deliver.ReturnDate = deliver.ReturnDate == null ? deliver.ReturnDate : DateConvertor.ToMiladi((DateTime)deliver.ReturnDate);
                deliver.DeliveryDate = DateConvertor.ToMiladi((DateTime)deliver.DeliveryDate);
                db.Entry(deliver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (deliver.DeliveryDate >= deliver.ReturnDate)
            {
                ViewBag.error = true;
            }
            ViewBag.ComputerID = new SelectList(db.Computer, "Computer_ID", "Computer_ID", deliver.ComputerID);
            ViewBag.UserID = new SelectList(db.User, "userID", "UserName", deliver.UserID);
            return View(deliver);
        }

        // GET: Admin/Delivers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deliver deliver = db.Deliver.Find(id);
            if (deliver == null)
            {
                return HttpNotFound();
            }
            return View(deliver);
        }

        // POST: Admin/Delivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deliver deliver = db.Deliver.Find(id);
            db.Deliver.Remove(deliver);
            db.SaveChanges();
            return RedirectToAction("Index");
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
