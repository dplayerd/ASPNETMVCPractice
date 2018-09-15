using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings.Manager
{
    public class HostManager
    {
        private Settings Settings = new Settings();

        /// <summary> 取得主控台資料 </summary>
        /// <returns></returns>
        public HostInfo GetHost()
        {
            return Settings.GetHost();
        }
    }
}
