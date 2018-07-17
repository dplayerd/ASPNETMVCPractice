using MVC3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC3.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        public ActionResult Menu()
        {
            var list = new Settings.Settings().getMenus(0);


            List<MenuViewModel> menuList =
                (from item in list
                 select
                     new MenuViewModel()
                     {
                         MenuID = item.MenuID,
                         Title = item.Title,
                         Action = item.Action,
                         Controller = item.Controller,
                         Class = "",
                         IsAction = item.IsAction,
                         Link = item.Link,
                         SubMenu = new List<MenuViewModel>()
                     }
                ).ToList();


            ////----- Menu1 -----
            //MenuViewModel menu = new MenuViewModel() { MenuID = 1, Action = "Index", Controller = "Dashboard", IsAction = true, Class = "class", SubMenu = null, Title = "Dashboard" };

            //menuList.Add(menu);
            ////----- Menu1 -----




            ////----- Menu1 -----
            //menu = new MenuViewModel() { MenuID = 2, IsAction = false, Class = "class", Link = "javascript:void(0);", Title = "Application Setup" };

            //menu.SubMenu = new List<MenuViewModel>() {
            //    new MenuViewModel() { Action = "Register", Controller = "Account", IsAction = true, Class = "", SubMenu = null, Title = "User Manager" },
            //    new MenuViewModel() { Action = "Index", Controller = "Manage", IsAction = true, Class = "", SubMenu = null, Title = "Manage" },
            //    new MenuViewModel() { Action = "ChangePassword", Controller = "Manage", IsAction = true, Class = "", SubMenu = null, Title = "Change Password" },
            //    new MenuViewModel() { IsAction = false, Link = "javascript:document.getElementById('logoutForm').submit()", Class = "", SubMenu = null, Title = "Logoff" }
            //};

            //menuList.Add(menu);
            ////----- Menu1 -----




            ////----- Menu1 -----
            //menu = new MenuViewModel()
            //{
            //    MenuID = 1,
            //    Action = "AjaxGo",
            //    Controller = "Home",
            //    IsAction = true,
            //    Class = "class",
            //    SubMenu = null,
            //    Title = "AjaxGo"
            //};

            //menuList.Add(menu);
            ////----- Menu1 -----


            return PartialView("_NavigationPartial", menuList);
        }
    }
}