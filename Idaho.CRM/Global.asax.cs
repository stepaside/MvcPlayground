using Microsoft.Practices.Unity;
using Idaho.CRM.Controllers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Idaho.CRM.App_Start;

namespace Idaho.CRM
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IUnityContainer Container { get; set; }
        
        protected void Application_Start()
        {
            Container = Bootstrapper.Initialize();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}