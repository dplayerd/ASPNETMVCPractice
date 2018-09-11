using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class ModuleContainerController : Controller
    {
        // GET: ModuleContainer
        public ActionResult Default()
        {
            return PartialView();
        }
    }
}