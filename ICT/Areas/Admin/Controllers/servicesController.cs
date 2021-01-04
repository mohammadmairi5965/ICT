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
    public class servicesController : Controller
    {
        private SoftwareReportEntities db = new SoftwareReportEntities();

        // GET: Admin/services
        public ActionResult search(string q)
        {
            ViewBag.q = q;
            return View(db.service.Where(c => c.Computer_ID.Contains(q)).OrderByDescending(c => c.dateOfService));
        }

        public ActionResult Index(string comid)
        {
            List<service> service = new List<service>();

            if (comid != null)
            {
                service = db.service.Where(u => u.Computer_ID == comid).ToList();
            }
            else
            {
                service = db.service.ToList();
            }
            ViewBag.id = comid;
            return View(service.OrderByDescending(c => c.dateOfService).ToList());
        }

        // GET: Admin/services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            service service = db.service.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: Admin/services/Create
        public ActionResult Create(string id)
        {
            ViewBag.Action = new SelectList(db.Action, "ActionID", "Title");
            var com = db.Computer.Select(c => new { name = c.Computer_ID + " " + c.unit, id = c.Computer_ID }).ToList();
            if (id == null || id == "")
            { ViewBag.Computer_ID = new SelectList(com, "id", "name"); }
            else
            {
                ViewBag.Computer_ID = new SelectList(com, "id", "name", id);
            }
            ViewBag.id = id;
            ViewBag.DisablementID = new SelectList(db.Disablement, "ID", "ComputerID");
            ViewBag.PeriodicVisitsID = new SelectList(db.PeriodicVisits, "ID", "Title");
            ViewBag.SoftwareID = new SelectList(db.Software, "ID", "Name");
            ViewBag.TypeOfServices = new SelectList(db.TypeOFService, "ID", "Title");

            return View();
        }

        // POST: Admin/services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,dateOfService,Computer_ID,SoftwareID,Action,DisablementID,ICTUser,PeriodicVisitsID,TypeOfServices")] service service)
        {
            if (ModelState.IsValid)
            {
                service.ICTUser = db.User.SingleOrDefault(u => u.UserName == User.Identity.Name).userID;
                service.dateOfService = DateConvertor.ToMiladi(service.dateOfService);
                // service.ServiceImage.Add(new ServiceImage() {ServiceID=service.ID,FileName=""});
                db.service.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index", new { comid = service.Computer_ID });
            }

            ViewBag.Action = new SelectList(db.Action, "ActionID", "Title", service.Action);
            ViewBag.Computer_ID = new SelectList(db.Computer, "Computer_ID", "Computer_ID", service.Computer_ID);
            ViewBag.DisablementID = new SelectList(db.Disablement, "ID", "ComputerID", service.DisablementID);
            ViewBag.PeriodicVisitsID = new SelectList(db.PeriodicVisits, "ID", "Title", service.PeriodicVisitsID);
            ViewBag.SoftwareID = new SelectList(db.Software, "ID", "Name", service.SoftwareID);
            ViewBag.TypeOfServices = new SelectList(db.TypeOFService, "ID", "Title", service.TypeOfServices);
            return View(service);
        }

        // GET: Admin/services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            service service = db.service.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.Action = new SelectList(db.Action, "ActionID", "Title", service.Action);
            ViewBag.Computer_ID = new SelectList(db.Computer, "Computer_ID", "Computer_ID", service.Computer_ID);
            ViewBag.DisablementID = new SelectList(db.Disablement, "ID", "ComputerID", service.DisablementID);
            ViewBag.PeriodicVisitsID = new SelectList(db.PeriodicVisits, "ID", "Title", service.PeriodicVisitsID);
            ViewBag.SoftwareID = new SelectList(db.Software, "ID", "Name", service.SoftwareID);
            ViewBag.TypeOfServices = new SelectList(db.TypeOFService, "ID", "Title", service.TypeOfServices);
            return View(service);
        }

        // POST: Admin/services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,dateOfService,Computer_ID,SoftwareID,Action,DisablementID,ICTUser,PeriodicVisitsID,TypeOfServices")] service service)
        {
            if (ModelState.IsValid)
            {
                service.dateOfService = DateConvertor.ToMiladi(service.dateOfService);
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { comid = service.Computer_ID });
            }
            ViewBag.Action = new SelectList(db.Action, "ActionID", "Title", service.Action);
            ViewBag.Computer_ID = new SelectList(db.Computer, "Computer_ID", "Computer_ID", service.Computer_ID);
            ViewBag.DisablementID = new SelectList(db.Disablement, "ID", "ComputerID", service.DisablementID);
            ViewBag.PeriodicVisitsID = new SelectList(db.PeriodicVisits, "ID", "Title", service.PeriodicVisitsID);
            ViewBag.SoftwareID = new SelectList(db.Software, "ID", "Name", service.SoftwareID);
            ViewBag.TypeOfServices = new SelectList(db.TypeOFService, "ID", "Title", service.TypeOfServices);

            return View(service);
        }

        // GET: Admin/services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            service service = db.service.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Admin/services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service service = db.service.Find(id);
            try
            {
                db.service.Remove(service);
                db.SaveChanges();
                return RedirectToAction("Index", new { comid = service.Computer_ID });
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
