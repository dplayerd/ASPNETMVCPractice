using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC3.Models
{
    public class MenuViewModel
    {
        public int MenuID { get; set; }

        public int SiteID { get; set; }

        public string Title { get; set; }

        public string Action { get; set; }

        public string Controller { get; set; }

        public bool IsAction { get; set; }

        public string Link { get; set; }

        public string Class { get; set; }

        public string PageFilePath { get; set; }

        public bool IsDefault { get; set; }

        public List<MenuViewModel> SubMenu { get; set; }
    }
}