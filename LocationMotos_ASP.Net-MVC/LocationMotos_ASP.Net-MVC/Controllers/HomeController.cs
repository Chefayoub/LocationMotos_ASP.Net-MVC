using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Data.Entity;
using System.Web.Mvc;
using LocationMotos_ASP.Net_MVC.Models;
using LocationMotos_ASP.Net_MVC.ViewModels;

namespace LocationMotos_ASP.Net_MVC.Controllers
{
    public class HomeController : Controller
    {
        private LocMotoDbContext db = new LocMotoDbContext();

        // Addition de 2 nombres
        public string Ajouter(int valeur1, int valeur2)
        {
            int resultat = valeur1 + valeur2;
            return resultat.ToString();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var motos = db.Motos.ToList();
            var marques = db.Marques.ToList();

            var rep = from c in marques
                      join r in motos on c.IDMarque equals r.IDMarque
                      select new LocationMotos_ASP.Net_MVC.ViewModels.AfficheMotoViewModels { marqueInfo = c, motoInfo = r };

            return View(rep);
        }

        [Authorize]
        public ActionResult AccueilConnecter()
        {
            ViewBag.Message = "Bienvenue";

            var clients = db.Clients.ToList();
            var reservations = db.Locations.ToList();

            var rep = from c in clients
                      join r in reservations on c.IDClient equals r.IDClient
                      where r.Date_debut.Day == DateTime.Now.Day
                      select new LocationMotos_ASP.Net_MVC.ViewModels.LocDuJourViewModels { clientInfo = c, locInfo = r };

            return View(rep);
        }

        [Route("/Home/ChercheMoto/{id}")]
        public ActionResult ChercheMoto(string id)
        {
            ViewBag.Message = "Bienvenue";
            ViewBag.id = id.ToString();

            var motos = db.Motos.ToList();
            var marques = db.Marques.ToList();

            var rep = from c in motos
                      join r in marques on c.IDMarque equals r.IDMarque
                      where c.Carburant == id
                      select new LocationMotos_ASP.Net_MVC.ViewModels.AfficheMotoViewModels { motoInfo = c, marqueInfo = r };

            return View(rep);
        }
    }
}