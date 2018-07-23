using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //----- Try path -----
            // 新增前台用路徑
            //url: "{SiteName}/{PageName}/
            // 考慮一下多 DOMAIN 對站台 (site1.www.xxxx.com / site2.www.xxxx.com)



            // 應改為後台用路徑
            routes.MapRoute(
                name: "PageRouting",
                url: "{SiteName}/{PageName}/{ModuleID}/{ModuleCtlName}/{Parameters}",
                defaults:
                    new
                    {
                        controller = "PageMenu",
                        action = "Default",

                        SiteName = UrlParameter.Optional,
                        PageName = UrlParameter.Optional,
                        ModuleID = UrlParameter.Optional,
                        ModuleCtlName = UrlParameter.Optional,
                        Parameters = UrlParameter.Optional
                    }
            );
            //----- Try path -----


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
