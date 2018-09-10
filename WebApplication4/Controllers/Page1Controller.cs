using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class Page1Controller : Controller
    {
        // GET: Page1
        public ActionResult Index()
        {
            string siteName = this.RouteData.Values["site"] as string;
            string ctlName = this.RouteData.Values["controller"] as string;
            string actName = this.RouteData.Values["action"] as string;
            string id = this.RouteData.Values["id"] as string;


            return View();
        }


        public ActionResult Detail()
        {
            return View();
        }
    }
}