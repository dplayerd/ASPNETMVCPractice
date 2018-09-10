using Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;

namespace MVC3.Controllers
{
    public class PageMenuController : Controller
    {
        public ActionResult Default(
                string ModuleCtlName,
                string ModuleID,
                string SiteName,
                string PageName,
                string Parameters
            )
        {
            ViewBag.SiteName = SiteName;
            ViewBag.PageName = PageName;
            ViewBag.ModuleID = ModuleID;
            ViewBag.ModuleCtlName = ModuleCtlName;
            ViewBag.Parameters = Parameters;


            var dto = UriHelper.getCurrentUri();


            ViewBag.SiteName = (dto.SiteID == -1) ? string.Empty : dto.SiteInfo.SiteName;
            ViewBag.PageName = (dto.PageID == -1) ? string.Empty : dto.PageInfo.Title;
            ViewBag.ModuleID = ModuleID;
            ViewBag.ModuleCtlName = ModuleCtlName;
            ViewBag.Parameters = Parameters;



            if (string.IsNullOrEmpty(SiteName) || string.IsNullOrEmpty(PageName))
            {
                UriHelper.genUri(dto.SiteID ?? 0, dto.PageID ?? 0);
            }


            


            if (dto.PageInfo != null)
            {
                Menu pageInfo = dto.PageInfo;


                if (!string.IsNullOrEmpty(pageInfo.PageFilePath))
                    //return RedirectToAction("Page", "Static", new { MenuTitle = pageInfo.Title });
                    return new StaticController().Page(pageInfo.Title);


                if (pageInfo.IsAction && !pageInfo.IsDefault)
                {
                    if (dto.PageInfo.Controller == "HtmlModule")
                        return new HtmlModuleController().ViewDetail(pageInfo.MenuID);

                    return RedirectToAction(dto.PageInfo.Action, dto.PageInfo.Controller);
                }


                if (pageInfo.IsDefault)
                    return View();
            }

            return View();
        }
    }
}