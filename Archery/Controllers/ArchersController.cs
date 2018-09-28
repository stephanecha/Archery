using Archery.Data;
using Archery.Models;
using Archery.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;

namespace Archery.Controllers
{
    public class ArchersController : BaseController
    {

       // private ArcheryDbContext db = new ArcheryDbContext();

        // GET: Players
        public ActionResult Subscribe()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Subscribe([Bind(Exclude="ID")] Archer archer)
        {
            //if (DateTime.Now.AddYears(-9) <= archer.BirthDate)
            //{
            //    ModelState.AddModelError("Birthdate", "Date de naissance invalide");
            //}
            //Md5 md5 = new Md5();
           // Md5.GetMd5Hash(Md5,archer.Password);

            if (ModelState.IsValid)
            {
                //...
                db.Archers.Add(archer);
                db.SaveChanges();
                //ViewData["Message"] = "BRAVO Archer enregistré";
                TempData["MessageType"] = "success";
                TempData["Message"] = "BRAVO Archer enregistré";
                Display("BRAVO Archer enregistré");
                return RedirectToAction("index", "home");
            }
            else
                ViewData["Message"] = "a marche pas";

            return View();
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                this.db.Dispose();
        }



    }
}