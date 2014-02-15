using MvcPlayground.Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPlayground.Controllers
{
    public class CitkaModuleController : CitkaController
    {
        public ModuleInstance Instance
        {
            get
            {
                return ViewBag.Instance as ModuleInstance;
            }
        }

        protected PartialViewResult CitkaModuleView(object model)
        {
            if (Instance.Module != null)
            {
                return base.PartialView(Instance.Module.ViewPath, model);
            }
            else
            {
                return base.PartialView();
            }
        }
    }
}
