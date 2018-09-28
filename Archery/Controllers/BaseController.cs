﻿using Archery.Data;
using Archery.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Controllers
{
    public class BaseController : Controller
    {
        protected ArcheryDbContext db = new ArcheryDbContext();

        /// <summary>
        /// Affiche un message dans le layout
        /// </summary>
        /// <param name="text"></param>
        /// <param name="type"></param>
        protected void Display(string text, MessageType type = MessageType.SUCCESS)
        {
            var m = new Message(type, text);
            TempData["MESSAGE"] = m;
                
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                this.db.Dispose();
        }


    }
}