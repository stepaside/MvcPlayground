using MvcPlayground.Models.Framework;
using System;
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
                            writer.Write(Html.Partial(container.Instance.Module.ControlPath, container.RetrieveModel()).ToHtmlString());
                        }
                        catch (Exception ex)
                        {
                            if (File.Exists(this.NormalizePath(container.Instance.Module.ErrorControlPath)))
                            {
                                writer.Write(Html.Partial(container.Instance.Module.ErrorControlPath, new ErrorModelView { Exception = ex, Model = container.RetrieveModel() }).ToHtmlString());
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