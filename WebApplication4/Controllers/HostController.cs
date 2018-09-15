using Settings;
using Settings.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class HostController:Controller
    {
        public ActionResult Default()
        {
            HostInfo host = new HostManager().GetHost();


            int defaultSiteID = host.DefaultSiteID;


            var site = new Settings.Settings().getSiteSetting(host.DefaultSiteID);
            var menu = new Settings.Settings().getDefaultMenu(site.SiteID);


            return RedirectToAction("Default", "ModuleContainer", new { site = site.SiteName, MenuTitle = menu.Title });
        }
    }
}