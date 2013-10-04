using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPlayground.Models.Product
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public ICollection<Price> Prices { get; set; }
    }
}