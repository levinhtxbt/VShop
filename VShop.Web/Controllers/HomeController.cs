using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VShop.Web.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CKFinder()
        {
            ViewBag.Message = "Welcome to CKFinder!";
            return View();
        }
    }
}