using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Idaho.CRM.Models.Framework
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public string Code { get; set; }
        public string Domain { get; set; }
        public string Version { get; set; }
        public ICollection<Page> Pages { get; set; }

        public Page SelectPageByName(string name)
        {
            if (Pages != null)
            {
                return Pages.FirstOrDefault(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
            }
            return null;
        }
    }
}