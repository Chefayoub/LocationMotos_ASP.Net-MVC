using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LocationMotos_ASP.Net_MVC.Models;

namespace LocationMotos_ASP.Net_MVC.Controllers
{
    [Authorize]
    public class MotosController : Controller
    {
        private LocMotoDbContext db = new LocMotoDbContext();

        // GET: Motos
        public ActionResult Index()
        {
            var motos = db.Motos.Include(m => m.Marque);
            return View(motos.ToList());
        }

        // GET: Motos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moto moto = db.Motos.Find(id);
            if (moto == null)
            {
                return HttpNotFound();
            }
            return View(moto);
        }

        // GET: Motos/Create
        public ActionResult Create()
        {
            ViewBag.IDMarque = new SelectList(db.Marques, "IDMarque", "MarqueM");
            return View();
        }

        // POST: Motos/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDMoto,Carburant,Kilometrage,Disponible,IDMarque")] Moto moto)
        {
            if (ModelState.IsValid)
            {
                db.Motos.Add(moto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDMarque = new SelectList(db.Marques, "IDMarque", "MarqueM", moto.IDMarque);
            return View(moto);
        }

        // GET: Motos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moto moto = db.Motos.Find(id);
            if (moto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDMarque = new SelectList(db.Marques, "IDMarque", "MarqueM", moto.IDMarque);
            return View(moto);
        }

        // POST: Motos/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMoto,Carburant,Kilometrage,Disponible,IDMarque")] Moto moto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDMarque = new SelectList(db.Marques, "IDMarque", "MarqueM", moto.IDMarque);
            return View(moto);
        }

        // GET: Motos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moto moto = db.Motos.Find(id);
            if (moto == null)
            {
                return HttpNotFound();
            }
            return View(moto);
        }

        // POST: Motos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Moto moto = db.Motos.Find(id);
            db.Motos.Remove(moto);
            db.SaveChanges();
            return RedirectToAction("Index");
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
