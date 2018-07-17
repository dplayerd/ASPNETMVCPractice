using System.Collections.Generic;

namespace Settings
{
    public class ModuleDefine
    {
        public ModuleDefine()
        {
            this.Defines = new Dictionary<string, ModulePageDefine>();
        }

        public string Name { get; set; }


        public Dictionary<string, ModulePageDefine> Defines { get; set; }
    }
}
