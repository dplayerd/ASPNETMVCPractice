using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC3.Controllers
{
    public class ModuleTestController : Controller
    {
        // GET: ModuleTest
        public ActionResult Index()
        {
            return PartialView();
        }


        public ActionResult GetView2()
        {
            return PartialView();
        }
    }
}