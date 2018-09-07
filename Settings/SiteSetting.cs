using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings
{
    public class SiteSetting
    {
        #region "Key Info"
        public int SiteID { get; set; }

        public string SiteName { get; set; }
        #endregion



        #region "Master Info"
        public List<string> DomainName { get; set; }

        public bool WillLockDomain { get; set; }


        public string SiteOwner { get; set; }

        public int SiteOwnerID { get; set; }

        public int DefaultSkinID { get; set; }

        public bool IsDefault { get; set; }
        #endregion



        #region "Desc Info"
        public string Logo { get; set; }
        public string HeaderText { get; set; }
        public string FooterText { get; set; }
        #endregion
    }
}
