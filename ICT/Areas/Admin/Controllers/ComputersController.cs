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
   // [Authorize(Roles = ("admin,software,hardware,network"))]
    public class ComputersController : Controller
    {
        private SoftwareReportEntities db = new SoftwareReportEntities();

        // GET: Admin/Computers

        public ActionResult Computerhardware(string q)
        {


            var ch = db.ComputerHardware.Where(h => h.ComputerID == q).ToList();
            ViewBag.q = q;
            //  var ch = db.Computer.Where(c => c.Computer_ID == q).Select(c => c.Hardware).FirstOrDefault();

            return PartialView(ch);
        }
        public IQueryable<DeliveryComputer> search(String comid, String typ, String unt, String cod, String sral, String dlv)
        {
            IQueryable<DeliveryComputer> tmp = db.DeliveryComputer;
            if (comid!="")
            {
                tmp = tmp.Where(c => c.Computer_ID.Contains(comid));
            }
            if (typ != "")
            {
                tmp = tmp.Where(c => c.Title.Contains(typ));
            }
            if (unt != "")
            {
                tmp = tmp.Where(c => c.unitTitle.Contains(unt));
            }
            if (cod != "")
            {
                tmp = tmp.Where(c => c.AmvalCode.Contains(cod));
            }
            if (sral != "")
            {
                tmp = tmp.Where(c => c.Serial.Contains(sral));
            }
            if (dlv != "")
            {
                tmp = tmp.Where(c => c.Name.Contains(dlv));
            }
            return tmp;
        }

        public ActionResult Index(int pageId = 1, String comid = "", String typ = "", String unt = "", String cod = "", String sral = "", String dlvr = "")
        {
            IQueryable<DeliveryComputer> dbcom = search(comid, typ, unt, cod, sral, dlvr);
            ViewBag.comid = comid;
            ViewBag.pageId = pageId;
            ViewBag.typ = typ;
            ViewBag.unt = unt;
            ViewBag.cod = cod;
            ViewBag.sral = sral;
            ViewBag.dlvr = dlvr;
            int take = 15;
            ViewBag.take = take;
            int skip = (pageId - 1) * take;
            ViewBag.PageCount = Math.Ceiling(dbcom.Count() / (double)take);
            var dcomputer = dbcom.OrderBy(c => new { c.Name, c.Computer_ID }).Skip(skip).Take(take);
            return View(dcomputer);
        }
        // GET: Admin/Computers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Computer computer = db.Computer.Find(id);
            if (computer == null)
            {
                return HttpNotFound();
            }
            return View(computer);
        }

        // GET: Admin/Computers/Create
        public ActionResult Create()
        {
            ViewBag.TypeOfComputer = new SelectList(db.ComputerType, "ID", "Title");
            ViewBag.unit = new SelectList(db.Unit, "ID", "Title");
            ViewBag.ClientUser = new SelectList(db.User, "userID", "UserName");
            return View();
        }

        // POST: Admin/Computers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Computer_ID,unit,TypeOfComputer,ClientUser,ComputerName,UserName,AmvalCode,Serial")] Computer computer)
        {
            if (ModelState.IsValid)
            {
                db.Computer.Add(computer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TypeOfComputer = new SelectList(db.ComputerType, "ID", "Title", computer.TypeOfComputer);
            ViewBag.unit = new SelectList(db.Unit, "ID", "Title", computer.unit);
            return View(computer);
        }
        [HttpPost]
        public string createID(int id)
        {
            ComputerType ct = db.ComputerType.Find(id);

            var a = db.Computer.Where(c => c.TypeOfComputer == id).Select(c => c.Computer_ID).Max();
            string s = ct.SubUnitID + (ct.ID < 10 ? "0" + ct.ID.ToString() : ct.ID.ToString()) + (a == null ? "0001" : (Convert.ToInt32(a) + 1).ToString().Substring(3, 4));
            return s;
        }


        // GET: Admin/Computers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Computer computer = db.Computer.Find(id);
            if (computer == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeOfComputer = new SelectList(db.ComputerType, "ID", "Title", computer.TypeOfComputer);
            ViewBag.unit = new SelectList(db.Unit, "ID", "Title", computer.unit);
            return View(computer);
        }

        // POST: Admin/Computers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Computer_ID,unit,TypeOfComputer,ClientUser,ComputerName,UserName,AmvalCode,Serial")] Computer computer)
        {
            if (ModelState.IsValid)
            {
                //computer.Hardware.Clear();
                //computer.Hardware.Add(db.Hardware.ToList()[1]);

                db.Entry(computer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeOfComputer = new SelectList(db.ComputerType, "ID", "Title", computer.TypeOfComputer);
            ViewBag.unit = new SelectList(db.Unit, "ID", "Title", computer.unit);
            return View(computer);
        }

        // GET: Admin/Computers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Computer computer = db.Computer.Find(id);
            if (computer == null)
            {
                return HttpNotFound();
            }
            return View(computer);
        }

        // POST: Admin/Computers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Computer computer = db.Computer.Find(id);

            try
            {
                db.Computer.Remove(computer);
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
