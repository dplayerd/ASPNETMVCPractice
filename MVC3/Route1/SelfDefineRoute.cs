using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MVC3.Route1
{
    public class SelfDefineRoute : Route
    {
        private const string DomainRouteInsertionsKey = "DomainRoute.Insertions";

        public string Domain { get; private set; }


        public SelfDefineRoute(string url, IRouteHandler routeHandler) : base(url, routeHandler)
        {
        }

        public SelfDefineRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler) : base(url, defaults, routeHandler)
        {
        }

        public SelfDefineRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler) : base(url, defaults, constraints, routeHandler)
        {
        }

        public SelfDefineRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler) : base(url, defaults, constraints, dataTokens, routeHandler)
        {
        }


        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var requestDomain = httpContext.Request.Url.Host;


            var data = base.GetRouteData(httpContext);


            data.Values["domain1"] = httpContext.Request.Url.Authority;
            this.Domain = httpContext.Request.Url.Authority;

            return data;
        }


        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            return base.GetVirtualPath(requestContext, RemoveDomainTokens(requestContext, values));
        }

        private RouteValueDictionary RemoveDomainTokens(RequestContext requestContext, RouteValueDictionary values)
        {
            var myInsertions = requestContext.HttpContext.Items[DomainRouteInsertionsKey] as HashSet<string>;

            if (myInsertions != null)
            {
                foreach (var key in myInsertions)
                {
                    if (values.ContainsKey(key))
                        values.Remove(key);
                }
            }

            return values;
        }
    }
}