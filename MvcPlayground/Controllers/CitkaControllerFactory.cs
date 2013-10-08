using Microsoft.Practices.Unity;
using MvcPlayground;
using MvcPlayground.Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unity.Mvc4;

namespace MvcPlayground.Controllers
{
    public class CitkaControllerFactory : DefaultControllerFactory
    {
        public readonly static string DefaultAction = "Index";

        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            var controllerType = base.GetControllerType(requestContext, controllerName);
            // if a controller wasn't found with a matching name, return our dynamic controller
            return controllerType ?? typeof(CitkaController);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            var controller = base.GetControllerInstance(requestContext, controllerType) as CitkaController;
            var actionInvoker = MvcApplication.Container.Resolve<IActionInvoker>("CitkaDynamicActionInvoker");
            if (actionInvoker != null)
            {
                controller.ActionInvoker = actionInvoker;
            }

            object appCode;
            requestContext.RouteData.Values.TryGetValue("application", out appCode);
            
            object appVersion;
            requestContext.RouteData.Values.TryGetValue("version", out appVersion);

            var pageName = Convert.ToString(requestContext.RouteData.Values["controller"]);
            
            object action;
            requestContext.RouteData.Values.TryGetValue("action", out action);
            if (action != null && action is string && (string)action != CitkaControllerFactory.DefaultAction)
            {
                pageName += action;
            }

            var app = appCode != null ? DataManager.GetApplication(Convert.ToString(appCode), Convert.ToString(appVersion)) : DataManager.GetApplication(requestContext.HttpContext.Request.Url.Host);

            var page = app.SelectPageByName(pageName);

            if (page != null)
            {
                page.Instances = DataManager.LoadInstances(page.PageId);
            }

            controller.ViewBag.Application = app;
            controller.ViewBag.Page = page;
            
            return controller;
        }
    }
}
