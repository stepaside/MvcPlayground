using MvcPlayground.Models;
using MvcPlayground.Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcPlayground.Controllers
{
    public class CitkaController : Controller
    {
        public Application Application
        {
            get
            {
                return ViewBag.Application as Application;
            }
        }

        public Page Page
        {
            get
            {
                return ViewBag.Page as Page;
            }
        }
        
        protected ViewResult CitkaView()
        {
            if (Page.Layout != null)
            {
                if (Page.Layout.Source != null)
                {
                    return base.View(Page.Layout.Source, Page.Layout);
                }
                else
                {
                    return base.View(Page.Layout);
                }
            }
            else
            {
                return base.View();
            }
        }
        
        protected void SetupModuleModel(string name, object model)
        {
            if (Page != null)
            {
                var container = Page.FindContainerByModuleName(name);
                if (container != null)
                {
                    container.MergeModel(model);
                }
            }
        }
    }
}
