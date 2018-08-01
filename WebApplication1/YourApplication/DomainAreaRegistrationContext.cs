using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1.YourApplication
{

    // For Areas routes
    public class DomainAreaRegistrationContext
    {
        private AreaRegistrationContext Context { get; set; }
        private DomainRouteCollection Routes { get; set; }

        public DomainAreaRegistrationContext(string domain, AreaRegistrationContext context)
        {
            Context = context;
            Routes = new DomainRouteCollection(domain, Context.Routes);
        }

        public Route MapRoute(string name, string url)
        {
            return MapRoute(name, url, null, null, null);
        }

        public Route MapRoute(string name, string url, object defaults)
        {
            return MapRoute(name, url, defaults, null, null);
        }

        public Route MapRoute(string name, string url, string[] namespaces)
        {
            return MapRoute(name, url, null, null, namespaces);
        }

        public Route MapRoute(string name, string url, object defaults, object constraints)
        {
            return MapRoute(name, url, defaults, constraints, null);
        }

        public Route MapRoute(string name, string url, object defaults, string[] namespaces)
        {
            return MapRoute(name, url, defaults, null, namespaces);
        }

        public Route MapRoute(string name, string url, object defaults, object constraints, string[] namespaces)
        {
            if (namespaces == null && Context.Namespaces != null)
                namespaces = Context.Namespaces.ToArray();

            var route = Routes.MapRoute(name, url, defaults, constraints, namespaces);
            route.DataTokens["area"] = Context.AreaName;

            // disabling the namespace lookup fallback mechanism keeps this area from accidentally picking up
            // controllers belonging to other areas
            bool useNamespaceFallback = (namespaces == null || namespaces.Length == 0);
            route.DataTokens["UseNamespaceFallback"] = useNamespaceFallback;

            return route;
        }
    }

}