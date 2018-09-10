using Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class UriHelper
    {
        static Dictionary<int, string> UriAndParam = new Dictionary<int, string>()
        {
            {0, "" },
            {1, "SiteID" },
            {2, "PageID" },
            {3, "MoudleID" },
            {4, "ModuleControl" },

        };


        public static UriDTO getCurrentUri()
        {
            System.Uri uri = System.Web.HttpContext.Current.Request.Url;


            if (uri == null)
                return null;


            UriDTO dto = new UriDTO();
            dto.Uri = uri;
            dto.DomainName = uri.Scheme + "://" + uri.Authority; 

            var mgr = new Settings.Settings();


            SiteSetting siteSetting = null;
            Menu pageSetting = null;

            if (uri.Segments.Length >= 2)
            {
                string SiteName = uri.Segments[1].Trim('/');
                SiteName = System.Web.HttpUtility.UrlDecode(SiteName);

                siteSetting = mgr.getSiteSetting(SiteName);
            }
            else
            {
                siteSetting = mgr.getDefaultSiteSetting();
            }

            dto.SiteInfo = siteSetting;
            dto.SiteID = (siteSetting != null) ? siteSetting.SiteID : -1;





            if (uri.Segments.Length >= 3)
            {
                string MenuName = uri.Segments[2].Trim('/');
                MenuName = System.Web.HttpUtility.UrlDecode(MenuName);

                // 如果是靜態頁時
                if (MenuName.CompareTo("Static") == 0 && uri.Segments.Length >= 5)
                {
                    MenuName = uri.Segments[4].Trim('/');
                }

                pageSetting = mgr.getMenu(MenuName, dto.SiteID ?? -1);
            }
            else
            {
                pageSetting = mgr.getDefaultMenu(dto.SiteID ?? -1);
            }

            dto.PageInfo = pageSetting;
            dto.PageID = (pageSetting != null) ? pageSetting.MenuID : -1;


            return dto;
        }


        public static string genUri(int SiteID)
        {
            // TODO implement here
            return "";
        }


        public static string genUri(int SiteID, int PageID)
        {
            UriDTO dto = UriHelper.getCurrentUri();


            SiteSetting site = new Settings.Settings().getSiteSetting(SiteID);

            if (site == null)
            {
                site = new Settings.Settings().getDefaultSiteSetting();
            }


            if (site == null)
                return dto.DomainName;



            Menu menu = new Settings.Settings().getMenu(PageID);

            if (menu == null)
            {
                menu = new Settings.Settings().getDefaultMenu(PageID);
            }


            if (menu == null)
                return dto.DomainName + "/" + site.SiteName;


            return
                dto.DomainName + "/" + site.SiteName + "/" + menu.Title;
        }


        public static string genStaticPageUri(int SiteID, int PageID)
        {
            UriDTO dto = UriHelper.getCurrentUri();


            SiteSetting site = new Settings.Settings().getSiteSetting(SiteID);

            if (site == null)
            {
                site = new Settings.Settings().getDefaultSiteSetting();
            }


            if (site == null)
                return dto.DomainName;



            Menu menu = new Settings.Settings().getMenu(PageID);

            if (menu == null)
            {
                menu = new Settings.Settings().getDefaultMenu(PageID);
            }


            if (menu == null)
                return dto.DomainName + "/" + site.SiteName;



            return
                dto.DomainName + "/" + site.SiteName + "/Static/Page/" + menu.Title;
        }



        public static string genUri(UriParams ParaList)
        {
            // TODO implement here
            return "";
        }
    }
}
