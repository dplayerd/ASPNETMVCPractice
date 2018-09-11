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
            return new List<PageModule>() { new PageModule() { MenuID = PageID, ContainerID = PageID, SortingOrder = 1, ModuleID = 1 } };
        }


        /// <summary> 查詢有哪些模組在指定頁面容器上 </summary>
        /// <param name="PageID"> 頁面編號 </param>
        /// <returns></returns>
        public List<PageModule> GetContainerModules(int ContainerID, int PageID)
        {
            return new List<PageModule>() { new PageModule() { MenuID = PageID, ContainerID = PageID, SortingOrder = 1, ModuleID = 1 } };
        }
    }
}
