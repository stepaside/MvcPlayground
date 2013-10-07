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
        public string ControlFile { get; set; }
        public string ErrorFile { get; set; }

        public string ControlPath
        {
            get
            {
                return string.Format("~/Modules/{0}/{1}", Name, ControlFile ?? "Index.cshtml");
            }
        }

        public string ErrorControlPath
        {
            get
            {
                return string.Format("~/Modules/{0}/{1}", Name, ErrorFile ?? "Error.cshtml");
            }
        }
    }
}