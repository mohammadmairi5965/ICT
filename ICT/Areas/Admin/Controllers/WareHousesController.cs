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
    public class WareHousesController : Controller
    {
        private SoftwareReportEntities db = new SoftwareReportEntities();

        // GET: Admin/WareHouses
        public ActionResult Index()
        {
            var wareHouse = db.WareHouse.Include(w => w.Hardware);
            return View(wareHouse.ToList());
        }

        // GET: Admin/WareHouses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WareHouse wareHouse = db.WareHouse.Find(id);
            if (wareHouse == null)
            {
                return HttpNotFound();
            }
            return View(wareHouse);
        }

        // GET: Admin/WareHouses/Create
        public ActionResult Create()
        {
            ViewBag.HardwareID = new SelectList(db.Hardware, "ID", "Name");
            return View();
        }

        // POST: Admin/WareHouses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WarehouseID,HardwareID,Tedad")] WareHouse wareHouse)
        {
            if (ModelState.IsValid)
            {
                db.WareHouse.Add(wareHouse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HardwareID = new SelectList(db.Hardware, "ID", "Name", wareHouse.HardwareID);
            return View(wareHouse);
        }

        // GET: Admin/WareHouses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WareHouse wareHouse = db.WareHouse.Find(id);
            if (wareHouse == null)
            {
                return HttpNotFound();
            }
            ViewBag.HardwareID = new SelectList(db.Hardware, "ID", "Name", wareHouse.HardwareID);
            return View(wareHouse);
        }

        // POST: Admin/WareHouses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WarehouseID,HardwareID,Tedad")] WareHouse wareHouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wareHouse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HardwareID = new SelectList(db.Hardware, "ID", "Name", wareHouse.HardwareID);
            return View(wareHouse);
        }

        // GET: Admin/WareHouses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WareHouse wareHouse = db.WareHouse.Find(id);
            if (wareHouse == null)
            {
                return HttpNotFound();
            }
            return View(wareHouse);
        }

        // POST: Admin/WareHouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WareHouse wareHouse = db.WareHouse.Find(id);
          
            try
            {
                db.WareHouse.Remove(wareHouse);
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
