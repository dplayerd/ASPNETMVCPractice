using Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class NavigationController : Controller
    {
        private static List<MenuViewModel> menuList = null;

        public void InitMenu()
        {
            if (NavigationController.menuList != null)
                return;

                
            string siteName = RouteData.Values["site"] as string;

            if (string.IsNullOrEmpty(siteName))
                return;

            SiteSetting site = new Settings.Settings().getSiteSetting(siteName);

            if (site == null)
                return;


            List<Menu> list = new Settings.Settings().getMenus(site.SiteID);

            menuList =
                (from item in list
                 select
                     new MenuViewModel()
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
                     }
                ).ToList();
        }


        // GET: Navigation
        public ActionResult Menu()
        {
            this.InitMenu();

            return PartialView("_NavigationPartial", NavigationController.menuList);
        }


        public ActionResult MenuItem(MenuViewModel menu)
        {
            this.InitMenu();

            return PartialView("_MenuItemPartial", menu);
        }


        public ActionResult Breadcrumbs()
        {
            this.InitMenu();

            throw new NotImplementedException();
        }
    }
}