using Idaho.CRM.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Idaho.CRM.Models.Framework
{
    public class Page
    {
        public int PageId { get; set; }
        public int ApplicationId { get; set; }
        public int LayoutId { get; set; }
        public string Name { get; set; }
        
        public ICollection<ModuleInstance> Instances { get; set; }

        private Layout _layout = null;
        public Layout Layout
        {
            get
            {
                if (_layout == null)
                {
                    _layout = DataManager.GetLayout(LayoutId);
                    var instancesByZone = Instances.GroupBy(i => i.Zone).ToDictionary(g => g.Key, g => g.ToList());
                    foreach (var zone in _layout.Zones)
                    {
                        List<ModuleInstance> instances;
                        if (instancesByZone.TryGetValue(zone.Name, out instances))
                        {
                            zone.Containers = instances.Select(i => new ModuleContainer() { Instance = i, ZoneName = zone.Name }).OrderBy(c => c.Instance.Index).ToList();
                        }
                    }
                }
                return _layout;
            }
        }

        public ModuleContainer FindContainerByModuleName(string name)
        {
            return Layout.Zones.SelectMany(z => z.Containers).FirstOrDefault(c => string.Equals(c.Instance.Module.Name, name, StringComparison.OrdinalIgnoreCase));
        }
    }
}