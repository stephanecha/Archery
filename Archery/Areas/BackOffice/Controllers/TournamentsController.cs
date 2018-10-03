﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Archery.Data;
using Archery.Models;

namespace Archery.Areas.BackOffice.Controllers
{
    public class TournamentsController : Controller
    {
        private ArcheryDbContext db = new ArcheryDbContext();

        // GET: BackOffice/Tournaments
        public ActionResult Index()
        {
            return View(db.Tournaments.ToList());
        }

        // GET: BackOffice/Tournaments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournaments.Include("Weapons").SingleOrDefault(x => x.ID == id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // GET: BackOffice/Tournaments/Create
        public ActionResult Create()
        {
            MultiSelectList weaponsValues = new MultiSelectList(db.Weapons, "ID", "Name");
            ViewBag.Weapons = weaponsValues;
            return View();
        }

        // POST: BackOffice/Tournaments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Location,StartDate,EndDate,ArcherCount,Price,Description")] Tournament tournament, int[] WeaponsID)
        {
            if (ModelState.IsValid)
            {
                /*tournament.Weapons = new List<Weapon>();
                foreach (var item in WeaponsID)
                {
                    tournament.Weapons.Add(db.Weapons.Find(item));
                }*/
                if (WeaponsID.Count() > 0)
                    tournament.Weapons = db.Weapons.Where(x => WeaponsID.Contains(x.ID)).ToList();

                db.Tournaments.Add(tournament);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            MultiSelectList weaponsValues = new MultiSelectList(db.Weapons, "ID", "Name");
            ViewBag.Weapons = weaponsValues;
            return View(tournament);
        }

        // GET: BackOffice/Tournaments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournaments.Include("Weapons").SingleOrDefault(x => x.ID == id);
            if (tournament == null)
            {
                return HttpNotFound();
            }

            MultiSelectList weaponsValues = new MultiSelectList(db.Weapons, "ID", "Name", tournament.Weapons.Select(x => x.ID));
            ViewBag.Weapons = weaponsValues;
            return View(tournament);
        }

        // POST: BackOffice/Tournaments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Location,StartDate,EndDate,ArcherCount,Price,Description")] Tournament tournament, int[] weaponsID)
        {

            db.Entry(tournament).State = EntityState.Modified; //ici on ouvre une donnée dans le cache avec l'id qui est l'id du tournament.

            /*tournament=*//*optionel*/
            db.Tournaments.Include("Weapons").SingleOrDefault(x => x.ID == tournament.ID);//stch lecture des weapon en base pour ce tournoi
            //ici entity va faire le lien entre tournament et db.Tournaments car ils ont le meme ID et que entity peut gerer un seul objet avec le meme ID.


            if (ModelState.IsValid)
            {
                
                if (weaponsID != null)
                    tournament.Weapons = db.Weapons.Where(x => weaponsID.Contains(x.ID)).ToList();//stch lecture des weapon en passé dans le post
                else
                    tournament.Weapons.Clear();

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            MultiSelectList weaponsValues = new MultiSelectList(db.Weapons, "ID", "Name");
            ViewBag.Weapons = weaponsValues;
            return View(tournament);
        }

        // GET: BackOffice/Tournaments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // POST: BackOffice/Tournaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tournament tournament = db.Tournaments.Find(id);
            db.Tournaments.Remove(tournament);
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
 
 