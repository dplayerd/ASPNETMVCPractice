using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication1.Route1;
using WebApplication1.YourApplication;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            //routes.Add(
            //     new Route1.Route123(
            //         domain: "{domain1}",
            //         url: "{controller}/{action}/{id}",
            //         defaults: new
            //         {
            //             controller = "Home",
            //             action = "Index",

            //             id = UrlParameter.Optional
            //         }
            //     )
            // );


            routes.Add(
                new RoutePractice(
                    domain: "{domain1}",
                    url: "{controller}/{action}/{id}",
                    defaults: new
                    {
                        controller = "Home",
                        action = "Index",

                        id = UrlParameter.Optional
                    }
                )
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
