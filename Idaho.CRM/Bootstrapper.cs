using Microsoft.Practices.Unity;
using Idaho.CRM.Controllers;
using System;
using System.Collections.Concurrent;
using System.Web.Mvc;
using Unity.Mvc4;

namespace Idaho.CRM
{
    public static class Bootstrapper
    {
        private static ConcurrentDictionary<string, Type> _commonActions = new ConcurrentDictionary<string, Type>();

        public static IUnityContainer Initialize()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IControllerFactory, CitkaControllerFactory>(new TransientLifetimeManager());
            container.RegisterType<IActionInvoker, CitkaDynamicActionInvoker>("CitkaDynamicActionInvoker", new TransientLifetimeManager());
        }



        public static void RegisterCommonAction<T>(string actionName)
            where T : CitkaDynamicActionDescriptor
        {
            if (!typeof(T).IsAbstract && !typeof(T).IsInterface)
            {
                _commonActions.AddOrUpdate(actionName, name => typeof(T), (name, type) => typeof(T));
            }
        }

        public static CitkaDynamicActionDescriptor ResolveCommonAction(string actionName, IUnityContainer container)
        {
            Type type;
            if (_commonActions.TryGetValue(actionName, out type))
            {
                return (CitkaDynamicActionDescriptor)container.Resolve(type);
            }
            return null;
        }
    }
}