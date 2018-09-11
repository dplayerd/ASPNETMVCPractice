using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings
{
    public class PageModule
    {
        #region " Page & Module "
        public int PageModuleID { get; set; }

        public int MenuID { get; set; }

        public int ModuleID { get; set; }
        #endregion


        #region "Info"
        public int ContainerID { get; set; }

        public int SortingOrder { get; set; }
        #endregion
    }
}
