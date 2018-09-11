using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings
{
    /// <summary> 模組定義 </summary>
    public class ModuleInfo
    {
        /// <summary> 模組定義編號 </summary>
        public int ModuleInfoID { get; set; }

        /// <summary> 模組全名 </summary>
        public string ModuleName { get; set; }

        /// <summary> 顯示用名稱 </summary>
        public string FriendlyName { get; set; }

        /// <summary> Action </summary>
        public string Action { get; set; }

        /// <summary> Controller </summary>
        public string Controller { get; set; }
    }

}
