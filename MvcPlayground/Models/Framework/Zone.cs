using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPlayground.Models.Framework
{
    public class Zone
    {
        public int LayoutId { get; set; }
        public string Name { get; set; }
        public ICollection<ModuleContainer> Containers { get; set; }
    }
}