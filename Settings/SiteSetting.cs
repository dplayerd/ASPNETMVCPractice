using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings
{
    public class SiteSetting
    {

        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string Logo { get; set; }
        public string HeaderText { get; set; }
        public string FooterText { get; set; }




        public string SiteOwner { get; set; }

        public int SiteOwnerID { get; set; }

        public int DefaultSkinID { get; set; }
    }
}
