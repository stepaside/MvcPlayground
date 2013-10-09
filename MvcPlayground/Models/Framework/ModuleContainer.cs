using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace MvcPlayground.Models.Framework
{
    public class ModuleContainer
    {
        public ModuleContainer()
        {
            ViewModel = new ExpandoObject();
        }

        public ModuleContainer(ModuleContainer container, object model)
        {
            Instance = container.Instance;
            ZoneName = container.ZoneName;

            dynamic viewModel = new ExpandoObject();
            var source = (ExpandoObject)container.ViewModel;
    
            foreach (var pair in (IDictionary<string, object>)source)
            {
                viewModel[pair.Key] = pair.Value;
            }

            if (model != null)
            {
                var viewModelAsMap = viewModel as IDictionary<string, object>;
                foreach(var property in model.GetType().GetProperties())
                {
                    viewModelAsMap[property.Name] = property.GetValue(model);
                }
            }

            viewModel.Instance = container.Instance;
            
            ViewModel = viewModel;
        }

        public string ZoneName { get; set; }
        public ModuleInstance Instance { get; set; }
        
        public dynamic ViewModel { get; private set; }
    }
}