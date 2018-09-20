using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings
{
    public partial class Settings
    {

        public Settings()
        {
            Settings.initHost();
            Settings.initSiteSettings();
            Settings.initMenus();
            Settings.initModuleInfos();
            Settings.initPageModules();
            Settings.initSkins();
        }


        #region "PageModule"
        internal static List<PageModule> _PageModules = null;

        private static void initPageModules()
        {
            if (_PageModules != null)
                return;


            Settings._PageModules = JsonReader.ReadFromFile<List<PageModule>>(JsonReader.PageModule);
        }
        #endregion


        #region "Module Info"
        internal static List<ModuleInfo> _ModuleInfo = null;


        private static void initModuleInfos()
        {
            if(_ModuleInfo != null)
                return;

            Settings._ModuleInfo = JsonReader.ReadFromFile<List<ModuleInfo>>(JsonReader.Module); 
        }

        public ModuleInfo getModuleInfo(int ModuleInfoID)
        {
            return Settings._ModuleInfo.Where(obj => obj.ModuleInfoID == ModuleInfoID).FirstOrDefault();
        }

        public ModuleInfo getModuleDefine(string ModuleName)
        {
            return Settings._ModuleInfo.Where(obj => obj.ModuleName == ModuleName || obj.FriendlyName == ModuleName).FirstOrDefault();
        }
        #endregion


        #region "Init Pages"
        internal static List<Menu> _Menus = null;

        private static void initMenus()
        {
            if (_Menus != null)
                return;


            Settings._Menus = JsonReader.ReadFromFile<List<Menu>>(JsonReader.Menu);
        }


        public Menu getMenu(int MenuID)
        {
            if (MenuID <= -1)
                return null;

            return Settings._Menus.Where(obj=>obj.MenuID == MenuID).FirstOrDefault();
        }


        public List<Menu> getMenus(int SiteID)
        {
            if (SiteID <= -1)
                return null;

            if (Settings._Menus == null)
                return null;

            return Settings._Menus.Where(obj => obj.SiteID == SiteID).ToList();
        }


        public Menu getMenu(string MenuName, int SiteID = 0)
        {
            if (SiteID <= -1)
                return null;

            // 找目標網頁
            Menu menu = Settings._Menus.Where(obj => string.Compare(obj.Title, MenuName, true) == 0 && obj.SiteID == SiteID).FirstOrDefault();

            if (menu != null)
                return menu;


            // 如果找不到，回預設值
            menu = Settings._Menus.Where(obj => obj.IsDefault == true).FirstOrDefault();

            if (menu != null)
                return menu;


            // 如果完全沒東西回傳，回 NULL
            return null;
        }


        /// <summary> 預設值 </summary>
        /// <param name="SiteID"></param>
        /// <returns></returns>
        public Menu getDefaultMenu(int SiteID)
        {
            // 如果找不到，回
            Menu menu = Settings._Menus.Where(obj => obj.IsDefault == true && obj.SiteID == SiteID).FirstOrDefault();

            if (menu != null)
                return menu;

            // 如果完全沒東西回傳，回 NULL
            return null;
        }
        #endregion


        #region "Init SiteSetting"
        internal static List<SiteSetting> _siteSettings = null;

        private static void initSiteSettings()
        {
            if (Settings._siteSettings != null)
                return;


            Settings._siteSettings = JsonReader.ReadFromFile<List<SiteSetting>>(JsonReader.Site);
        }


        public List<SiteSetting> getSiteSettings()
        {
            return Settings._siteSettings;
        }


        public SiteSetting getSiteSetting(int SiteID)
        {
            if (SiteID <= -1)
                return null;

            return Settings._siteSettings.Where(obj => obj.SiteID == SiteID).FirstOrDefault();
        }

        public SiteSetting getSiteSetting(string SiteName)
        {
            // 找目標網頁
            SiteSetting site = Settings._siteSettings.Where(obj => string.Compare(obj.SiteName, SiteName, true) == 0).FirstOrDefault();

            if (site != null)
                return site;


            // 如果找不到，回預設值
            return this.getDefaultSiteSetting();
        }


        /// <summary> 預設值 </summary>
        /// <returns></returns>
        public SiteSetting getDefaultSiteSetting()
        {
            // 找目標網頁
            SiteSetting site = Settings._siteSettings.Where(obj => obj.IsDefault == true).FirstOrDefault();

            if (site != null)
                return site;


            // 如果完全沒東西回傳，回 NULL
            return null;
        }
        #endregion


        #region "HostInfo"
        internal static HostInfo _hostInfo = null;

        private static void initHost()
        {
            if (_hostInfo != null)
                return;


            Settings._hostInfo = JsonReader.ReadFromFile<HostInfo>(JsonReader.Host);
        }


        internal HostInfo GetHost()
        {
            return Settings._hostInfo;
        }
        #endregion


        #region "Init Skins"
        internal static List<Skin> _skins = null;

        private static void initSkins()
        {
            if (Settings._skins != null)
                return;


            Settings._skins = new List<Skin>()
            {
                new Skin()
                {
                    SkinID = 0,
                    FilePath = "/Views/Shared/_Layout.cshtml"
                },

                new Skin()
                {
                    SkinID = 1,
                    FilePath = "/Views/Shared/_LayoutPractice.cshtml"
                },

                new Skin()
                {
                    SkinID = 2,
                    FilePath = "/Views/Shared/_Layout.cshtml"
                }
            };
        }



        private Skin getSkin(int SkinID)
        {
            return Settings._skins.Where(obj => obj.SkinID == SkinID).FirstOrDefault();
        }

        public Skin getSiteSkin(int SiteID)
        {
            var siteSetting = Settings._siteSettings.Where(obj => obj.SiteID == SiteID).FirstOrDefault();

            if (siteSetting == null)
                return null;


            int SkinID = siteSetting.DefaultSkinID;
            return this.getSkin(SkinID);
        }


        public Skin getMenuSkin(int MenuID)
        {
            var menu = this.getMenu(MenuID);

            if (menu == null)
                return null;


            if (menu.MenuSkinID.HasValue)
                return this.getSkin(menu.MenuSkinID.Value);


            int SiteID = menu.SiteID;
            return this.getSiteSkin(SiteID);
        }
        #endregion
    }
}
