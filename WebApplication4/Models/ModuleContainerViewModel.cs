using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    /// <summary> 模組容器 ViewModel </summary>
    public class ModuleContainerViewModel
    {
        /// <summary> 頁面編號 </summary>
        public int PageID { get; set; }


        /// <summary> 模組定義編號 </summary>
        public int ModuleInfoID { get; set; }


        /// <summary> 模組實體編號 </summary>
        public int PageModuleID { get { return this.PageID; } }


        /// <summary> ControllerName </summary>
        public string ControllerName { get; set; }


        /// <summary> ActionName </summary>
        public string ActionName { get; set; }
    }
}