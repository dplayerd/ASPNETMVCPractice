﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC3.Controllers
{
    public class HtmlModuleController : Controller
    {
        public ActionResult ViewDetail(int ModuleInstanceID = 0)
        {
            return PartialView();
        }
    }
}