using Idaho.CRM.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Idaho.CRM.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "DefaultNoAction",
                url: "{application}/{version}/{controller}/{id}",
                defaults: new { controller = "Home", action = CitkaControllerFactory.DefaultAction },
                constraints: new RouteValueDictionary { { "application", @"\w{4}" }, { "version", @"\d+\.\d+(\.\d+)?" }, { "id", @"\d+" } }
            );

            routes.MapRoute(
                name: "DefaultNoVersionNoAction",
                url: "{application}/{controller}/{id}",
                defaults: new { controller = "Home", action = CitkaControllerFactory.DefaultAction },
                constraints: new RouteValueDictionary { { "application", @"\w{4}" }, { "id", @"\d+" } }
            );

            routes.MapRoute(
                name: "DefaultNoApplicationNoVersionNoAction",
                url: "{controller}/{id}",
                defaults: new { controller = "Home", action = CitkaControllerFactory.DefaultAction },
                constraints: new RouteValueDictionary { { "id", @"\d+" } }
            );

            routes.MapRoute(
                name: "Default",
                url: "{application}/{version}/{controller}/{action}",
                defaults: new { controller = "Home", action = CitkaControllerFactory.DefaultAction },
                constraints: new RouteValueDictionary { { "application", @"\w{4}" }, { "version", @"\d+\.\d+(\.\d+)?" } }
            );

            routes.MapRoute(
                name: "DefaultNoVersion",
                url: "{application}/{controller}/{action}",
                defaults: new { controller = "Home", action = CitkaControllerFactory.DefaultAction },
                constraints: new RouteValueDictionary { { "application", @"\w{4}" } }
            );

            routes.MapRoute(
                name: "DefaultNoApplicationNoVersion",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = CitkaControllerFactory.DefaultAction }
            );
        }
    }
}