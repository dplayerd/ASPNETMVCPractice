using Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class UriDTO
    {

        public Uri Uri { get; set; }

        public string DomainName { get; set; }

        public int? SiteID { get; set; }

        public SiteSetting SiteInfo { get; set; }

        public int? PageID { get; set; }

        public Menu PageInfo { get; set; }


        public int? ModuleID { get; set; }

        public int? ModuleControlID { get; set; }

        public string[][] GenericKeyValue { get; set; }

    }
}
