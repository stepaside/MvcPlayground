using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Idaho.CRM.Models.Framework
{
    public class ModuleInstance
    {
        public int InstanceId { get; set; }
        public Module Module { get; set; }
        public string Zone { get; set; }
        public int Index { get; set; }
    }
}