using Settings;
using Settings.Manager;
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


            List<PageModule> pageModules =
                new PageModuleManager().GetPageModules(page.MenuID);


            Dictionary<int, ModuleInfo> dicModuleInfo =
                (from item in new Settings.Settings().getModuleInfoList(pageModules.Select(obj => obj.ModuleInfoID).ToArray())
                 select item).ToDictionary(obj => obj.ModuleInfoID, obj => obj);


            List<ModuleContainerViewModel> VMs =
                (from item in pageModules
                 select new ModuleContainerViewModel
                 {
                     PageModuleID = item.PageModuleID,
                     PageID = page.MenuID,
                     ModuleInfoID = dicModuleInfo[item.ModuleInfoID].ModuleInfoID,
                     ActionName = dicModuleInfo[item.ModuleInfoID].ModuleView[0].Action,
                     ControllerName = dicModuleInfo[item.ModuleInfoID].ModuleView[0].Controller
                 }).ToList();



            return View(VMs);
        }
    }
}