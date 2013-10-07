using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPlayground.Models.Framework
{
    public class ErrorModelView
    {
        public object Model { get; set; }
        public Exception Exception { get; set; }
    }
}