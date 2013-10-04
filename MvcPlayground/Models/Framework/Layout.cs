using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPlayground.Models.Framework
{
    public class Layout
    {
        public int LayoutId { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public ICollection<Zone> Zones { get; set; }

        public Zone this[string name]
        {
            get
            {
                return Zones.FirstOrDefault(z => string.Equals(z.Name, name, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}