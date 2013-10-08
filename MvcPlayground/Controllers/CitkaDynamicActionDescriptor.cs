using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPlayground.Controllers
{
    public abstract class CitkaDynamicActionDescriptor : ActionDescriptor
    {
        private string _actionName;
        private ControllerDescriptor _controllerDescriptor;
        private List<ParameterDescriptor> _parameters;

        public CitkaDynamicActionDescriptor()
        {
            _parameters = new List<ParameterDescriptor>();
        }

        public override string ActionName
        {
            get { return _actionName; }
        }

        public override ControllerDescriptor ControllerDescriptor
        {
            get { return _controllerDescriptor; }
        }

        public override ParameterDescriptor[] GetParameters()
        {
            return _parameters.ToArray();
        }

        public void AddParameter<T>(string name)
        {
            _parameters.Add(new CitkaDynamicParameterDescriptor(this, name, typeof(T)));
        }

        public virtual void SetActionName(string actionName)
        {
            _actionName = actionName;
        }

        public virtual void SetControllerDescriptor(ControllerDescriptor controllerDescriptor)
        {
            _controllerDescriptor = controllerDescriptor;
        }
    }
}