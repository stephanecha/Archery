using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Areas.BackOffice.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: BackOffice/Authentication
        public ActionResult Login()
        {
            return View();
        }
    }
}