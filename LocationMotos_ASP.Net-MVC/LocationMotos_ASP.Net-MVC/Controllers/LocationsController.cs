﻿using System;
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
    public class LocationsController : Controller
    {
        private LocMotoDbContext db = new LocMotoDbContext();

        // GET: Locations
        public ActionResult Index()
        {
            var locations = db.Locations.Include(l => l.Client).Include(l => l.Moto);
            return View(locations.ToList());
        }

        // GET: Locations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // GET: Locations/Create
        public ActionResult Create()
        {
            ViewBag.IDClient = new SelectList(db.Clients, "IDClient", "Nom");
            ViewBag.IDMoto = new SelectList(db.Motos, "IDMoto", "Carburant");
            return View();
        }

        // POST: Locations/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLocation,Nom,Prenom,Adresse,NumeroTel,IDClient,IDMoto")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Locations.Add(location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDClient = new SelectList(db.Clients, "IDClient", "Nom", location.IDClient);
            ViewBag.IDMoto = new SelectList(db.Motos, "IDMoto", "Carburant", location.IDMoto);
            return View(location);
        }

        // GET: Locations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDClient = new SelectList(db.Clients, "IDClient", "Nom", location.IDClient);
            ViewBag.IDMoto = new SelectList(db.Motos, "IDMoto", "Carburant", location.IDMoto);
            return View(location);
        }

        // POST: Locations/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLocation,Nom,Prenom,Adresse,NumeroTel,IDClient,IDMoto")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDClient = new SelectList(db.Clients, "IDClient", "Nom", location.IDClient);
            ViewBag.IDMoto = new SelectList(db.Motos, "IDMoto", "Carburant", location.IDMoto);
            return View(location);
        }

        // GET: Locations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Location location = db.Locations.Find(id);
            db.Locations.Remove(location);
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
