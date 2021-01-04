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
    //[Authorize(Roles = ("admin"))]
    public class ComputerHardwaresController : Controller
    {
        private SoftwareReportEntities db = new SoftwareReportEntities();

        // GET: Admin/ComputerHardwares
        
        public ActionResult Index(string id,string hardware)
        {
            
            var computerHardware = db.ComputerHardware.Include(c => c.Computer).Include(c => c.Hardware);
            if (id != "" && id!=null)
            {
                computerHardware = db.ComputerHardware.Where(c => c.ComputerID.Contains(id)).Include(c => c.Computer).Include(c => c.Hardware);
            }
            if (hardware!="" && hardware != null)
            {
                computerHardware= computerHardware.Where(c => c.Hardware.Name.Contains(hardware)).Include(c => c.Computer).Include(c => c.Hardware);
            }

            ViewBag.id = id;
            return View(computerHardware.ToList());
        }
        //{
        //    ComputerType ct = db.ComputerType.Find(id);

        //    var a = db.Computer.Where(c => c.TypeOfComputer == id).Select(c => c.Computer_ID).Max();
        //    string s = ct.SubUnitID + (ct.ID < 10 ? "0" + ct.ID.ToString() : ct.ID.ToString()) + (a == null ? "0001" : (Convert.ToInt32(a) + 1).ToString().Substring(3, 4));
        //    return s;
        //}
        // GET: Admin/ComputerHardwares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerHardware computerHardware = db.ComputerHardware.Find(id);
            if (computerHardware == null)
            {
                return HttpNotFound();
            }
            return View(computerHardware);
        }

        // GET: Admin/ComputerHardwares/Create
        public ActionResult Create(string id)
        {
            ViewBag.ComputerID = new SelectList(db.Computer, "Computer_ID", "Computer_ID",id);
            ViewBag.HardwareID = new SelectList(db.Hardware, "ID", "Name");
            return View();
        }

        // POST: Admin/ComputerHardwares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComputerHardwareID,ComputerID,HardwareID,AmvalCode,Serial")] ComputerHardware computerHardware)
        {
            if (ModelState.IsValid)
            {
                db.ComputerHardware.Add(computerHardware);
                db.SaveChanges();
                return RedirectToAction("Index",new {id = computerHardware.ComputerID});
            }

            ViewBag.ComputerID = new SelectList(db.Computer, "Computer_ID", "Computer_ID", computerHardware.ComputerID);
            ViewBag.HardwareID = new SelectList(db.Hardware, "ID", "Name", computerHardware.HardwareID);
            return View(computerHardware);
        }

        // GET: Admin/ComputerHardwares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerHardware computerHardware = db.ComputerHardware.Find(id);
            if (computerHardware == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComputerID = new SelectList(db.Computer, "Computer_ID", "Computer_ID", computerHardware.ComputerID);
            ViewBag.HardwareID = new SelectList(db.Hardware, "ID", "Name", computerHardware.HardwareID);
            return View(computerHardware);
        }

        // POST: Admin/ComputerHardwares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComputerHardwareID,ComputerID,HardwareID,AmvalCode,Serial")] ComputerHardware computerHardware)
        {
            if (ModelState.IsValid)
            {
                db.Entry(computerHardware).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = computerHardware.ComputerID });
            }
            ViewBag.ComputerID = new SelectList(db.Computer, "Computer_ID", "Computer_ID", computerHardware.ComputerID);
            ViewBag.HardwareID = new SelectList(db.Hardware, "ID", "Name", computerHardware.HardwareID);
            return View(computerHardware);
        }

        // GET: Admin/ComputerHardwares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComputerHardware computerHardware = db.ComputerHardware.Find(id);
            if (computerHardware == null)
            {
                return HttpNotFound();
            }
            return View(computerHardware);
        }

        // POST: Admin/ComputerHardwares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComputerHardware computerHardware = db.ComputerHardware.Find(id);
            String comID = computerHardware.ComputerID;
            //db.ComputerHardware.Remove(computerHardware);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            try
            {
                db.ComputerHardware.Remove(computerHardware);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = comID});
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
