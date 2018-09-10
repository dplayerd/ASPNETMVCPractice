using Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    /// <summary> Uri 資料 </summary>
    public class UriDTO
    {
        /// <summary> 原始 URI </summary>
        public Uri Uri { get; set; }

        /// <summary> DomainName (ex. http://www.google.com/ ) </summary>
        public string DomainName { get; set; }

        /// <summary> 網站代碼 </summary>
        public int? SiteID { get; set; }

        public SiteSetting SiteInfo { get; set; }

        public int? PageID { get; set; }

        public Menu PageInfo { get; set; }


        public int? ModuleID { get; set; }

        public int? ModuleControlID { get; set; }

        public int? ModuleInstanceID { get { return this.PageID; } }

        public string[][] GenericKeyValue { get; set; }

    }
}
