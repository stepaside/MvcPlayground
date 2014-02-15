using MvcPlayground.Controllers;
using MvcPlayground.Models;
using MvcPlayground.Models.Framework;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.WebPages;

namespace MvcPlayground.Views
{
    public abstract class CitkaViewPage : WebViewPage<Layout>
    {
        private IControllerFactory _factory = ControllerBuilder.Current.GetControllerFactory();

        private static ConcurrentDictionary<string, bool> _controllers = new ConcurrentDictionary<string, bool>();

        public HelperResult RenderZone(string name)
        {
            Action<TextWriter> action = writer =>
            {
                var zone = Model[name];
                if (zone != null)
                {
                    foreach (var container in zone.Containers)
                    {
                        try
                        {
                            var controllerExists = _controllers.GetOrAdd(container.Instance.Module.ControllerName, controllerName =>
                            {
                                IController controller = null;
                                try
                                {
                                    controller = _factory.CreateController(this.Request.RequestContext, controllerName);
                                }
                                catch { }
                                return controller != null && (!(controller is CitkaController) || controller.GetType() != typeof(CitkaController));
                            });

                            if (controllerExists)
                            {
                                var actionName = Path.GetFileNameWithoutExtension(container.Instance.Module.ControlFile) ?? CitkaControllerFactory.DefaultAction;
                                writer.Write(Html.Action(actionName, container.Instance.Module.ControllerName).ToHtmlString());
                            }
                            else
                            {
                                writer.Write(Html.Partial(container.Instance.Module.ViewPath, (object)container.ViewModel).ToHtmlString());
                            }
                        }
                        catch (Exception ex)
                        {
                            if (File.Exists(this.NormalizePath(container.Instance.Module.ErrorControlPath)))
                            {
                                container.ViewModel.Exception = ex;
                                writer.Write(Html.Partial(container.Instance.Module.ErrorControlPath, (object)container.ViewModel).ToHtmlString());
                            }
                        }
                    }
                }
            };
            return new HelperResult(action);
        }
    }

    public abstract class CitkaViewPage<T> : CitkaViewPage
        where T : Layout
    {
    }
}