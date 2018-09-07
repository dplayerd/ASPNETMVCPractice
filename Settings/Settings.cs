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
            Settings.initModuleDefines();
            Settings.initMenus();
            Settings.initSiteSettings();
            Settings.initSkins();
        }


        #region "Module Define"
        private static List<ModuleDefine> _ModuleDefines = null;

        private static void initModuleDefines()
        {
            if (_ModuleDefines != null)
                return;

            Settings._ModuleDefines = new List<ModuleDefine>()
            {
                new ModuleDefine()
                {
                    Name = "Module1 Test",
                    Defines = new Dictionary<string, ModulePageDefine>()
                    {
                        { "", new ModulePageDefine (){ Name="", Action="Index", Controller="ModuleTest" } },
                        { "Second", new ModulePageDefine(){ Name = "Second", Action = "GetView2", Controller = "ModuleTest" } }
                    }
                },

                new ModuleDefine()
                {
                    Name = "Calendar",
                    Defines = new Dictionary<string, ModulePageDefine>()
                    {
                        { "", new ModulePageDefine (){ Name="", Action="Index", Controller="Calendar" } },
                        { "Edit", new ModulePageDefine (){ Name="Edit", Action="EditPage", Controller="Calendar" } },
                        { "Tip", new ModulePageDefine (){ Name="Tip", Action="Created", Controller="Calendar" } },
                    }
                }
            };
        }

        public ModuleDefine getModuleDefine(string ModuleName)
        {
            return Settings._ModuleDefines.Where(obj => obj.Name == ModuleName).FirstOrDefault();
        }
        #endregion


        #region "Init Pages"
        private static List<Menu> _Menus = null;

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

            return Settings._Menus;
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
        private static List<SiteSetting> _siteSettings = null;

        private static void initSiteSettings()
        {
            if (Settings._siteSettings != null)
                return;


            Settings._siteSettings = JsonReader.ReadFromFile<List<SiteSetting>>(JsonReader.Site);
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


        #region "Init Skins"
        private static List<Skin> _skins = null;

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
