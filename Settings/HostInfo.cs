using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings
{
    /// <summary> 主控台資料 </summary>
    public class HostInfo
    {
        /// <summary> 名稱 </summary>
        public string HostName { get; set; }

        /// <summary> 顯示用名稱 </summary>
        public string Title { get; set; }

        /// <summary> 主控台 DomainName (NULL 時不做限制) </summary>
        public string DomainName { get; set; }

        /// <summary> 主控台預設站台編號 </summary>
        public int DefaultSiteID { get; set; }

        /// <summary> 主控台預設 SKIN 編號 </summary>
        public int DefaultSkinID { get; set; }
    }
}
