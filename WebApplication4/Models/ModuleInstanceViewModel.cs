using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class ModuleInstanceViewModel
    {
        public int ModuleInstance { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }
    }
}