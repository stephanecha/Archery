using Archery.Areas.BackOffice.Models;
using Archery.Controllers;
using Archery.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Areas.BackOffice.Controllers
{
    public class AuthenticationController : BaseController
    {
        // GET: BackOffice/Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AuthenticationLoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var admin = db.Administrators.SingleOrDefault(
                    x => x.Mail == model.Mail && x.Password == model.Password);
                if (admin == null)
                {
                    ModelState.AddModelError("Mail", "Login/mdp invalid");
                    return View();

                }
                else
                {
                    return RedirectToAction("Index", "Dashboard", new { aera = "backoffice" });
                }

            }



            return View();
        }
    }
}