using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace MvcPlayground.Models.Framework
{
    public class ModuleContainer
    {
        private ModuleInstance _instance;

        public ModuleContainer()
        {
            ViewModel = new ExpandoObject();
        }

        public void MergeModel(object model)
        {
            var viewModel = (ExpandoObject)ViewModel;
    
            if (model != null)
            {
                var viewModelAsMap = viewModel as IDictionary<string, object>;
                foreach(var property in model.GetType().GetProperties())
                {
                    viewModelAsMap[property.Name] = property.GetValue(model);
                }
            }
        }

        public string ZoneName { get; set; }
        public ModuleInstance Instance
        {
            get
            {
                return _instance;
            }
            set
            {
                _instance = value;
                ViewModel.Instance = value;
            }
        }
        
        public dynamic ViewModel { get; private set; }
    }
}