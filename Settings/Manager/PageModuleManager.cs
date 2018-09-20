using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings.Manager
{
    /// <summary> 頁面模組管理員 </summary>
    public class PageModuleManager
    {
        private Settings Settings = new Settings();

        /// <summary> 查詢有哪些模組在指定頁面上 </summary>
        /// <param name="PageID"> 頁面編號 </param>
        /// <returns></returns>
        public List<PageModule> GetPageModules(int PageID)
        {
            var query =
                from item in Settings._PageModules
                where 
                    item.MenuID == PageID
                select item;

            var result = query.ToList();
            return result;
        }



        /// <summary> 查詢有哪些模組在指定頁面容器上 </summary>
        /// <param name="PaneName"> 頁面區域名稱 </param>
        /// <param name="PageID"> 頁面編號 </param>
        /// <returns></returns>
        public List<PageModule> GetContainerModules(string PaneName, int PageID)
        {
            var query =
              from item in Settings._PageModules
              where
                  item.MenuID == PageID &&
                  item.PaneName.CompareTo(PaneName) == 0
              select item;

            var result = query.ToList();
            return result;
        }
    }
}
