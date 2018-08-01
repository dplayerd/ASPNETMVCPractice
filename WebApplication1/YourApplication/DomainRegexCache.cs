using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1.YourApplication
{
    internal static class DomainRegexCache
    {
        // since we're often going to have the same pattern used in multiple routes, it's best to build just one regex per pattern
        private static ConcurrentDictionary<string, Regex> _domainRegexes = new ConcurrentDictionary<string, Regex>();

        internal static Regex CreateDomainRegex(string domain)
        {
            return _domainRegexes.GetOrAdd(domain, (d) =>
            {
                d = d.Replace("/", @"\/")
                     .Replace(".", @"\.")
                     .Replace("-", @"\-")
                     .Replace("{", @"(?<")
                     .Replace("}", @">(?:[a-zA-Z0-9_-]+))");

                return new Regex("^" + d + "$", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture);
            });
        }
    }

}