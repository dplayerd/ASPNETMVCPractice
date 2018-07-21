using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC3.Controllers
{
    public class PageMenuController : Controller
    {
        public ActionResult Default(
                string ModuleCtlName,
                string ModuleID,
                string SiteName,
                string PageName,
                string Parameters
            )
        {
            ViewBag.SiteName = SiteName;
            ViewBag.PageName = PageName;
            ViewBag.ModuleID = ModuleID;
            ViewBag.ModuleCtlName = ModuleCtlName;
            ViewBag.Parameters = Parameters;


            return View();
        }
    }
}