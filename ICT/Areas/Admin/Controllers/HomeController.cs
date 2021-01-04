using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICT.Areas.Admin.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Header()
        {
            return PartialView();
        }

        public ActionResult Sidbar()
        {
            return PartialView();
        }

        public ActionResult Task()
        {
            return PartialView();
        }
    }
}