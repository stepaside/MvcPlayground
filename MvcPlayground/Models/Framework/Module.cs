using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPlayground.Models.Framework
{
    public class Module
    {
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string File { get; set; }

        public string Control
        {
            get
            {
                return string.Format("~/Modules/{0}/{1}", Name, File ?? "Index.cshtml");
            }
        }
    }
}