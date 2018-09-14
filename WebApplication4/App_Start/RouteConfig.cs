using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            string defaultSiteName = getDefaultSiteName();

            routes.MapRoute(
                name: "Default",
                url: "{site}/{controller}/{action}/{id}",
                defaults: new
                {
                    site = defaultSiteName,
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional,
                }
            );



            //routes.MapRoute(
            //    name: "Default",
            //    url: "{site}/{controller}/{action}/{id}",
            //    defaults: new
            //    {
            //        site = defaultSiteName,
            //        controller = "Home",
            //        action = "Index",
            //        id = UrlParameter.Optional,
            //    }
            //);
        }


        private static string getDefaultSiteName()
        {
            var defaultSite =
                new Settings.Settings().getDefaultSiteSetting();

            string defaultSiteName =
                (defaultSite == null) ?
                    "Default" :
                    defaultSite.SiteName;
            return defaultSiteName;
        }
    }
}
