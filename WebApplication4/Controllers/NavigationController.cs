using Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class NavigationController : Controller
    {
        #region "Private"
        private static List<MenuViewModel> menuList = null;

        private void InitMenu()
        {
            //if (NavigationController.menuList != null)
            //    return;


            string siteName = RouteData.Values["site"] as string;

            if (string.IsNullOrEmpty(siteName))
                return;

            SiteSetting site = new Settings.Settings().getSiteSetting(siteName);

            if (site == null)
                return;


            List<Menu> list = new Settings.Settings().getMenus(site.SiteID);
            List<MenuViewModel> models = new List<MenuViewModel>();

            Dictionary<int, MenuViewModel> topMenus = GenerateMenuTree(list);

            menuList = topMenus.Values.ToList();
        }


        private Dictionary<int, MenuViewModel> GenerateMenuTree(List<Menu> list)
        {
            // Key: TopMenuID
            // Value: SubMenus
            Dictionary<int, List<MenuViewModel>> dicSubMenus = new Dictionary<int, List<MenuViewModel>>();

            // Key: MenuID
            // Value: MenuViewModel
            Dictionary<int, MenuViewModel> dicMenus = new Dictionary<int, MenuViewModel>();

            // Key: MenuID
            // Value: MenuViewModel
            Dictionary<int, MenuViewModel> topMenus = new Dictionary<int, MenuViewModel>();


            // 做物件轉換，以及產生樹狀清單
            foreach (Menu menu in list)
            {
                if (dicMenus.ContainsKey(menu.MenuID))
                    continue;


                var model = this.ConvertMenu(menu);
                dicMenus.Add(menu.MenuID, model);



                if (!menu.TopMenuID.HasValue)
                {
                    topMenus.Add(menu.MenuID, model);
                }
                else
                {
                    int topID = menu.TopMenuID.Value;

                    if (!dicSubMenus.ContainsKey(topID))
                        dicSubMenus.Add(topID, new List<MenuViewModel>());

                    dicSubMenus[topID].Add(model);


                    // 尋找屬於自己的母節點
                    if (dicMenus.ContainsKey(topID))
                        dicMenus[topID].SubMenu = dicSubMenus[topID];
                }

                // 尋找屬於自己的子節點
                if (dicSubMenus.ContainsKey(menu.MenuID))
                {
                    model.SubMenu = dicSubMenus[menu.MenuID];
                }
            }

            return topMenus;
        }


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
        #endregion


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


            string siteName = this.RouteData.Values["site"] as string;

            SiteSetting site = new Settings.Settings().getSiteSetting(siteName);

            if (site == null)
                return new EmptyResult();



            //TODO: 這裡不好，要改
            string title = Request.QueryString["MenuTitle"];

            Menu page = new Settings.Settings().getMenu(title, site.SiteID);
            Menu topPage = page;


            List<MenuViewModel> models = new List<MenuViewModel>() { this.ConvertMenu(page) };

            while (topPage.TopMenuID.HasValue)
            {
                topPage = new Settings.Settings().getMenu(page.TopMenuID.Value);

                if (topPage == null)
                    break;

                models.Insert(0, this.ConvertMenu(topPage));
            }

            return PartialView("_BreadcrumbPartial", models);
        }
    }
}