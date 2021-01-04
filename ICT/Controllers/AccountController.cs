using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataLayer;

namespace ICT.Controllers
{
    public class AccountController : Controller
    {
        SoftwareReportEntities db = new SoftwareReportEntities();

        #region Login
        
        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }
        [Route("Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login, FormCollection form, string ReturnUrl = "/")
        {
            string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(login.Password, "MD5");
            var user = db.User.SingleOrDefault(u => u.UserName == login.UserName && u.Password == hashPassword);
            if (user != null)
            {
                if (user.IsActive)
                {
                    ViewBag.roletype = db.User.SingleOrDefault(u => u.UserName == login.UserName && u.Password == hashPassword).RoleID;
                    FormsAuthentication.SetAuthCookie(user.UserName, login.RememberMe);
                    return Redirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("UserName", "حساب کاربری شما فعال نشده است");
                }
            }
            else
            {
                ModelState.AddModelError("UserName", "کاربری با اطلاعات وارد شده یافت نشد");
            }
            return View(login);
        }
        #endregion
        [Route("LogOff")]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        public ActionResult ChangePassword()
        {
            var user = db.User.Single(u => u.UserName == User.Identity.Name);
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel change)
        {

            if (ModelState.IsValid)
            {
                var user = db.User.Single(u => u.UserName == User.Identity.Name);
                ViewBag.Name = user;
                string oldPasswordhash = FormsAuthentication.HashPasswordForStoringInConfigFile(change.OldPassword, "MD5");
                if (user.Password == oldPasswordhash)
                {
                    string hashNewPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(change.Password, "MD5");
                    user.Password = hashNewPassword;
                    db.SaveChanges();
                    ViewBag.Success = true;
                }
                else
                {
                    ModelState.AddModelError("oldPassword", "کلمه عبور فعلی صحیح نمی باشد.");
                }
            }
            return View("SuccessChangPassword");
        }
    }
}