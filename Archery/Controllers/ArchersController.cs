﻿using Archery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Controllers
{
    public class ArchersController : Controller
    {
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
            }
            return View();
        }






    }
}