using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings
{
    public class Menu
    {
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

        /// <summary> 靜態連結 </summary>
        /// <param name="MenuID"></param>
        /// <param name="Name"></param>
        /// <param name="Link"></param>
        public Menu(int SiteID, int MenuID, string Name, string Link) :
            this(SiteID, MenuID, Name)
        {
            this.Link = Link;
            this.IsAction = false;
        }



        public int MenuID { get; private set; }
        public string Title { get; private set; }
        public string Action { get; private set; }
        public string Controller { get; private set; }
        public bool IsAction { get; private set; }
        public string Link { get; private set; }

        //public List<Menu> SubMenu { get; set; }

        public int? MenuSkinID { get; set; }


        public int SiteID { get; set; }
    }
}
