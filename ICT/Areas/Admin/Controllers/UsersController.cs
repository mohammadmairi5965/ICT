using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataLayer;

namespace ICT.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private SoftwareReportEntities db = new SoftwareReportEntities();

        // GET: Admin/Users

        public ActionResult searchByName(string uname)
        {
            var users = db.User.Where(u => u.Name.Contains(uname) || u.UserName.Contains(uname)).ToList();
            return View(users);
        }
        public ActionResult Index(int pageId = 1)
        {
            var users = db.User.Include(u => u.Role);
            ViewBag.pageId = pageId;
            //Pagging
            int take = 10;
            int skip = (pageId - 1) * take;
            ViewBag.PageCount = users.Count() / take;

            return View(users.OrderBy(p => p.UserName).Skip(skip).Take(take).ToList());
        }
        //public ActionResult Index()
        //{
        //    var user = db.User.Include(u => u.Role);
        //    return View(user.ToList());
        //}

        // GET: Admin/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.Role, "RoleID", "RoleTitle");
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,RoleID,UserName,Password,Mobile,ActiveCode,IsActive,RegisterDate,PersonalImage,Name,DomainUserName")] User user)
        {
            if (ModelState.IsValid)
            {
                user.ActiveCode = Guid.NewGuid().ToString();
                user.IsActive = true;
                user.RegisterDate = DateTime.Now;
                user.PersonalImage = "images.jpg";
                user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(user.Password, "MD5");
                db.User.Add(user);
               

                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }

                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.Role, "RoleID", "RoleTitle", user.RoleID);
            return View(user);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.Role, "RoleID", "RoleTitle", user.RoleID);
            return View(user);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,RoleID,UserName,Password,Mobile,ActiveCode,IsActive,RegisterDate,PersonalImage,Name,DomainUserName")] User user)
        {
            if (ModelState.IsValid)
            {
                
                if (user.Password != db.User.Where(u => u.userID == user.userID).Select(u => u.Password).First())
                {
                    user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(user.Password, "MD5");
                }

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.Role, "RoleID", "RoleTitle", user.RoleID);
            return View(user);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
          
            try
            {
                db.User.Remove(user);
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
