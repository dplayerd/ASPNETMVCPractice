using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC3.Controllers
{
    public class StaticController : Controller
    {
        // GET: Static
        public ActionResult Index(string MenuTitle)
        {
            var list = new Settings.Settings().getMenus(0);

            var menuInfo = 
                list.Where(obj => string.Compare(MenuTitle, obj.Title, true) == 0).FirstOrDefault();



            if (menuInfo == null)
                return new EmptyResult();
                

            string IOPath = Server.MapPath(menuInfo.PageFilePath);


            if (!System.IO.File.Exists(IOPath))
                return Redirect("~/");


            string htmlContent =
                System.IO.File.ReadAllText(IOPath);


            return Content(htmlContent, "text/html");
        }
    }
}