using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Mvc4;

namespace MvcPlayground.Controllers
{
    public class CitkaDynamicActionInvoker : ControllerActionInvoker
    {
        protected override ActionDescriptor FindAction(ControllerContext controllerContext, ControllerDescriptor controllerDescriptor, string actionName)
        {
            var action = base.FindAction(controllerContext, controllerDescriptor, actionName);
            if (action == null)
            {
                var citkaAction = Bootstrapper.ResolveCommonAction(actionName, MvcApplication.Container);
                if (citkaAction != null)
                {
                    citkaAction.SetActionName(actionName);
                    citkaAction.SetControllerDescriptor(controllerDescriptor);
                    action = citkaAction;
                }
            }
            return action;            
        }
    }
}