using Microsoft.Practices.Unity;
using MvcPlayground.Controllers;
using System.Web.Mvc;
using Unity.Mvc4;

namespace MvcPlayground
{
  public static class Bootstrapper
  {
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
  }
}