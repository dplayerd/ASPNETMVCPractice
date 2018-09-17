using Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private MenuViewModel ConvertMenu(Menu item)
        {
            return new MenuViewModel()
            {
                MenuID = item.MenuID,
                SiteID = item.SiteID,
                Title = item.Title,
                Action = item.Action,
                Controller = item.Controller,
                Class = "",
                IsAction = item.IsAction,
                Link = item.Link,
                PageFilePath = item.PageFilePath,
                SubMenu = new List<MenuViewModel>()
            };
        }

        public ActionResult Index()
        {
            string SiteName = this.RouteData.Values["Site"] as string;
            var site = new Settings.Settings().getSiteSetting(SiteName);

            if (site == null)
                return new EmptyResult();


            var menu = new Settings.Settings().getDefaultMenu(site.SiteID);
            //return RedirectToAction("Default", "ModuleContainer", new { site = site.SiteName, MenuTitle = menu.Title });

            var page1 = this.ConvertMenu(menu);
            return View(page1);
        }
    }
}
