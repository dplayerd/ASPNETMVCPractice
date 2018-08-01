using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1.YourApplication
{


    #region "DomainRouteCollection"
    // For MVC routes
    public class DomainRouteCollection
    {
        private string Domain { get; set; }
        private RouteCollection Routes { get; set; }

        public DomainRouteCollection(string domain, RouteCollection routes)
        {
            Domain = domain;
            Routes = routes;
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
            if (name == null)
                throw new ArgumentNullException("name");
            if (url == null)
                throw new ArgumentNullException("url");

            var route = new DomainRoute(Domain, url, defaults, new MvcRouteHandler())
            {
                Constraints = new RouteValueDictionary(constraints),
                DataTokens = new RouteValueDictionary()
            };

            if (namespaces != null && namespaces.Length > 0)
                route.DataTokens["Namespaces"] = namespaces;

            Routes.Add(name, route);

            return route;
        }
    }
    #endregion
}