using Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class StaticController : Controller
    {
        // GET: Static
        public ActionResult Page(string MenuTitle)
        {
            if (string.IsNullOrEmpty(MenuTitle))
                return new EmptyResult();



            var mgr = new Settings.Settings();



            string siteName = RouteData.Values["site"] as string;
            SiteSetting site = mgr.getSiteSetting(siteName);



            Menu menuInfo = mgr.getMenu(MenuTitle, site.SiteID);



            if (menuInfo == null)
                return new EmptyResult();


            if (MenuTitle.CompareTo(menuInfo.Title) != 0)
                return new EmptyResult();


            string IOPath = System.Web.HttpContext.Current.Server.MapPath(menuInfo.PageFilePath);


            if (!System.IO.File.Exists(IOPath))
                return Redirect("~/");


            string htmlContent =
                System.IO.File.ReadAllText(IOPath);


            return Content(htmlContent, "text/html");
        }
    }
}