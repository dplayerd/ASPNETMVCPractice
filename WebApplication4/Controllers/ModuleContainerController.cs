using Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ModuleContainerController : Controller
    {
        // GET: ModuleContainer
        public ActionResult Default(string MenuTitle)
        {
            string siteName = RouteData.Values["site"] as string;

            if (string.IsNullOrEmpty(siteName))
                return new EmptyResult();


            SiteSetting site = new Settings.Settings().getSiteSetting(siteName);

            if (site == null)
                return new EmptyResult();


            Menu page = new Settings.Settings().getMenu(MenuTitle, site.SiteID);

            if (page == null)
                return new EmptyResult();


            var model = new ModuleContainerViewModel()
            {
                PageID = page.MenuID,
                ActionName = page.Action,
                ControllerName = page.Controller
            };


            return View(model);
        }
    }
}