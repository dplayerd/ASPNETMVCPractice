using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;

namespace WebApplication1.YourApplication
{

    // for WebApi routes
    public class DomainHttpRouteCollection
    {
        private string Domain { get; set; }
        private HttpRouteCollection Routes { get; set; }

        public DomainHttpRouteCollection(string domain, HttpRouteCollection routes)
        {
            Domain = domain;
            Routes = routes;
        }

        public IHttpRoute MapDomainHttpRoute(string name, string routeTemplate)
        {
            return MapDomainHttpRoute(name, routeTemplate, null, null, null);
        }

        public IHttpRoute MapDomainHttpRoute(string name, string routeTemplate, object defaults)
        {
            return MapDomainHttpRoute(name, routeTemplate, defaults, null, null);
        }

        public IHttpRoute MapDomainHttpRoute(string name, string routeTemplate, object defaults, object constraints)
        {
            return MapDomainHttpRoute(name, routeTemplate, defaults, constraints, null);
        }

        public IHttpRoute MapDomainHttpRoute(string name, string routeTemplate, object defaults, object constraints, HttpMessageHandler handler)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (routeTemplate == null)
                throw new ArgumentNullException("routeTemplate");

            var route = new DomainHttpRoute(Domain, routeTemplate, new HttpRouteValueDictionary(defaults), new HttpRouteValueDictionary(constraints));

            Routes.Add(name, route);

            return route;
        }
    }
}