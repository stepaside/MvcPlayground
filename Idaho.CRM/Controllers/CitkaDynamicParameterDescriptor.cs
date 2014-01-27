using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Idaho.CRM.Controllers
{
    public class CitkaDynamicParameterDescriptor : ParameterDescriptor
    {
        private ActionDescriptor _actionDescriptor;
        private string _parameterName;
        private Type _parameterType;

        public CitkaDynamicParameterDescriptor(ActionDescriptor actionDescriptor, string parameterName, Type parameterType)
        {
            _actionDescriptor = actionDescriptor;
            _parameterName = parameterName;
            _parameterType = parameterType;
        }

        public override ActionDescriptor ActionDescriptor
        {
            get { return _actionDescriptor; }
        }

        public override string ParameterName
        {
            get { return _parameterName; }
        }

        public override Type ParameterType
        {
            get { return _parameterType; }
        }
    }
}