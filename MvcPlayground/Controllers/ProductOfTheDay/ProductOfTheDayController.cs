using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPlayground.Controllers.ProductOfTheDay
{
    public class ProductOfTheDayController : CitkaModuleController
    {
        public PartialViewResult Index()
        {
            return CitkaModuleView(new Models.Product.Product() { Name = "My Product" });
        }

    }
}
