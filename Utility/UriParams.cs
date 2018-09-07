using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class UriParams
    {
        public int? SiteID { get; set; }

        public int? PageID { get; set; }

        public int? ModuleID { get; set; }

        public int? ModuleControlID { get; set; }

        public string[][] GenericKeyValue { get; set; }
    }
}
