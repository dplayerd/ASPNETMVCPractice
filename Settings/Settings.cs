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

            Settings._Menus = new List<Menu>()
            {
                new Menu(1, 1, "Google", "https://www.google.com/"),
                new Menu(1, 2, "Home",  "Index", "Home"),
                new Menu(1, 3, "Ajax", "AjaxGo", "Home"),
            };
        }


        public Menu getMenu(int MenuID)
        {
            return Settings._Menus.Where(obj=>obj.MenuID == MenuID).FirstOrDefault();
        }


        public List<Menu> getMenus(int SiteID)
        {
            return Settings._Menus;
        }
        #endregion


        #region "Init SiteSetting"
        private static List<SiteSetting> _siteSettings = null;

        private static void initSiteSettings()
        {
            if (Settings._siteSettings != null)
                return;


            Settings._siteSettings = new List<SiteSetting>()
            {
                new SiteSetting()
                {
                    SiteID = 1,
                    SiteName = "優秀的某間科技",
                    SiteOwner = "host",
                    SiteOwnerID = 1,
                    Logo = "/Images/Logo.png",
                    HeaderText = "歡迎來到某間科技公司",
                    FooterText = "某間科技版權所有 © 2015 Some All Rights Reserved",

                    DefaultSkinID = 1
                }
            };
        }


        public SiteSetting getSiteSetting(int SiteID)
        {
            return Settings._siteSettings.Where(obj => obj.SiteID == SiteID).FirstOrDefault();
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
