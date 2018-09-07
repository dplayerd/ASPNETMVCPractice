using MVC3.Models;
using Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC3.Controllers
{
    public class NavigationController : Controller
    {
        private static List<MenuViewModel> menuList = null;


        public NavigationController()
        {
            if (NavigationController.menuList != null)
                return;


            List<Menu> list = new Settings.Settings().getMenus(0);

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
            return PartialView("_NavigationPartial", NavigationController.menuList);
        }


        public ActionResult Breadcrumbs()
        {
            throw new NotImplementedException();
        }
    }
}