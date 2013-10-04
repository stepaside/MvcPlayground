using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPlayground.Models.Framework
{
    public class ModuleContainer
    {
        public string ZoneName { get; set; }
        public ModuleInstance Instance { get; set; }
        public virtual object RetrieveModel()
        {
            return Instance;
        }
    }

    public class ModuleContainer<T> : ModuleContainer
    {
        public ModuleContainer(ModuleContainer container)
        {
            Instance = container.Instance;
            ZoneName = container.ZoneName;
        }

        public T Entity { get; set; }

        public override object RetrieveModel()
        {
            return Entity;
        }
    }
}