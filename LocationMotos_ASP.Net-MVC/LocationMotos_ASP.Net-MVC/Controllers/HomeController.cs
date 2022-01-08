using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocationMotos_ASP.Net_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult AccueilConnecter()
        {
            ViewBag.Message = "Bienvenur";

            return View();
        }
    }
}