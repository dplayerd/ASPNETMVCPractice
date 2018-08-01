using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http.Routing;

namespace WebApplication1.YourApplication
{

    // WebApi Routes
    public class DomainHttpRoute : HttpRoute
    {
        private const string DomainRouteMatchKey = "DomainHttpRoute.Match";
        private const string DomainRouteInsertionsKey = "DomainHttpRoute.Insertions";

        private Regex _domainRegex;
        public string Domain { get; private set; }

        public DomainHttpRoute(string domain)
            : this(domain, (string)null, (HttpRouteValueDictionary)null, (HttpRouteValueDictionary)null, (HttpRouteValueDictionary)null, (HttpMessageHandler)null)
        {
        }

        public DomainHttpRoute(string domain, string routeTemplate)
            : this(domain, routeTemplate, (HttpRouteValueDictionary)null, (HttpRouteValueDictionary)null, (HttpRouteValueDictionary)null, (HttpMessageHandler)null)
        {
        }

        public DomainHttpRoute(string domain, string routeTemplate, HttpRouteValueDictionary defaults)
            : this(domain, routeTemplate, defaults, (HttpRouteValueDictionary)null, (HttpRouteValueDictionary)null, (HttpMessageHandler)null)
        {
        }

        public DomainHttpRoute(string domain, string routeTemplate, HttpRouteValueDictionary defaults, HttpRouteValueDictionary constraints)
            : this(domain, routeTemplate, defaults, constraints, (HttpRouteValueDictionary)null, (HttpMessageHandler)null)
        {
        }

        public DomainHttpRoute(string domain, string routeTemplate, HttpRouteValueDictionary defaults, HttpRouteValueDictionary constraints, HttpRouteValueDictionary dataTokens)
            : this(domain, routeTemplate, defaults, constraints, dataTokens, (HttpMessageHandler)null)
        {
        }

        public DomainHttpRoute(string domain, string routeTemplate, HttpRouteValueDictionary defaults, HttpRouteValueDictionary constraints, HttpRouteValueDictionary dataTokens, HttpMessageHandler handler)
            : base(routeTemplate, defaults, constraints, dataTokens, handler)
        {
            Domain = domain;
            _domainRegex = DomainRegexCache.CreateDomainRegex(Domain);
        }

        public override IHttpRouteData GetRouteData(string virtualPathRoot, HttpRequestMessage request)
        {
            var requestDomain = request.RequestUri.Host;

            var domainMatch = _domainRegex.Match(requestDomain);
            if (!domainMatch.Success)
                return null;

            object existingMatch;
            if (!request.Properties.TryGetValue(DomainRouteMatchKey, out existingMatch))
                request.Properties[DomainRouteMatchKey] = Domain;
            else if (Domain != existingMatch as string)
                return null;

            var data = base.GetRouteData(virtualPathRoot, request);
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

            request.Properties[DomainRouteInsertionsKey] = myInsertions;
            return data;
        }

        public override IHttpVirtualPathData GetVirtualPath(HttpRequestMessage request, IDictionary<string, object> values)
        {
            return base.GetVirtualPath(request, RemoveDomainTokens(request, values));
        }

        private IDictionary<string, object> RemoveDomainTokens(HttpRequestMessage request, IDictionary<string, object> values)
        {
            var myInsertions = request.Properties[DomainRouteInsertionsKey] as HashSet<string>;

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