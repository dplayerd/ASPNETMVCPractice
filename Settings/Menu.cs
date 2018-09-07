using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings
{
    public class Menu
    {
        #region "Constructor"
        internal Menu()
        { }

        private Menu(int SiteID, int MenuID, string Title)
        {
            this.MenuID = MenuID;
            this.Title = Title;
        }

        /// <summary> MVC </summary>
        /// <param name="MenuID"></param>
        /// <param name="Name"></param>
        /// <param name="Action"></param>
        /// <param name="Controller"></param>
        public Menu(int SiteID, int MenuID, string Name, string Action, string Controller) :
            this(SiteID, MenuID, Name)
        {
            this.Action = Action;
            this.Controller = Controller;
            this.IsAction = true;
        }

        /// <summary> 外部靜態連結 </summary>
        /// <param name="MenuID"></param>
        /// <param name="Name"></param>
        /// <param name="Link"></param>
        public Menu(int SiteID, int MenuID, string Name, string Link) :
            this(SiteID, MenuID, Name)
        {
            this.Link = Link;
            this.IsAction = false;
        }


        public Menu(int SiteID, int MenuID, string Name, string PageFilePath, int CacheTime) :
            this(SiteID, MenuID, Name)
        {
            this.PageFilePath = PageFilePath;
        }
        #endregion



        #region "Property"
        public int MenuID { get; set; }
        public string Title { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public bool IsAction { get; set; }
        public string Link { get; set; }

        public int? MenuSkinID { get; set; }

        public int SiteID { get; set; }

        public bool IsDefault { get; set; }

        public string PageFilePath { get; set; }
        #endregion
    }
}
