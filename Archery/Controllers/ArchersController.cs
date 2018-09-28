using Archery.Data;
using Archery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Subscribe(Archer archer)
        {
            //if (DateTime.Now.AddYears(-9) <= archer.BirthDate)
            //{
            //    ModelState.AddModelError("Birthdate", "Date de naissance invalide");
            //}
            if(ModelState.IsValid)
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