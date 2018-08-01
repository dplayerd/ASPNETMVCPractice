using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC3.Controllers
{
    public class PaneModuleController : Controller
    {
        public ActionResult GetPageModules(string PageName)
        {
            return PartialView();
        }


        public ActionResult GetPanes(string PageName)
        {
            return PartialView();
        }


        // GET: PaneModule
        public ActionResult GetModules(string PaneName)
        {
            return PartialView();
        }
    }
}