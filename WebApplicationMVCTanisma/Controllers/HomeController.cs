using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationMVCTanisma.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Anasayfa()
        {
            return View();
        }
        public ActionResult Deniyorum()
        {
            ViewBag.Ad = "Betül";
            ViewData["Ad"] = "Betül";
            TempData["Adiniz"] = "Betül";
            return View();
        }
    }
}