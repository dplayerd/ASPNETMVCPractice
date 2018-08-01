using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication1.YourApplication;

namespace WebApplication1.Route1
{
    public class Route123 : Route
    {
        private const string DomainRouteMatchKey = "DomainRoute.Match";
        private const string DomainRouteInsertionsKey = "DomainRoute.Insertions";

        private Regex _domainRegex;
        public string Domain { get; private set; }

        public Route123(string domain, string url, RouteValueDictionary defaults)
            : this(domain, url, defaults, new MvcRouteHandler())
        {
        }

        public Route123(string domain, string url, object defaults)
            : this(domain, url, new RouteValueDictionary(defaults), new MvcRouteHandler())
        {
        }

        public Route123(string domain, string url, object defaults, IRouteHandler routeHandler)
            : this(domain, url, new RouteValueDictionary(defaults), routeHandler)
        {
        }

        public Route123(string domain, string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
            : base(url, defaults, routeHandler)
        {
            Domain = domain;
            _domainRegex = DomainRegexCache.CreateDomainRegex(Domain);
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var requestDomain = httpContext.Request.Url.Host;

            var domainMatch = _domainRegex.Match(requestDomain);
            if (!domainMatch.Success)
                return null;

            var existingMatch = httpContext.Items[DomainRouteMatchKey] as string;

            if (existingMatch == null)
                httpContext.Items[DomainRouteMatchKey] = Domain;
            else if (existingMatch != Domain)
                return null;

            var data = base.GetRouteData(httpContext);
            if (data == null)
                return null;

            var myInsertions = new HashSet<string>();

            for (var i = 1; i < domainMatch.Groups.Count; i++)
            {
                var group = domainMatch.Groups[i];
                if (group.Success)
                {
                    var key = _domainRegex.GroupNameFromNumber(i);
                    if (!String.IsNullOrEmpty(key) && !String.IsNullOrEmpty(group.Value))
                    {
                        // could throw here if data.Values.ContainsKey(key) if we wanted to prevent multiple matches
                        data.Values[key] = group.Value;
                        myInsertions.Add(key);
                    }
                }
            }

            httpContext.Items[DomainRouteInsertionsKey] = myInsertions;
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