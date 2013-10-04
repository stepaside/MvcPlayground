using MvcPlayground.Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPlayground.Controllers.Product
{
    public class ProductController : CitkaController
    {
        public ViewResult Index(int id)
        {
            var model = DataManager.GetProduct(id);
            SetupModuleModel("ProductDetail", model);
            SetupModuleModel("ProductOfTheDay", model);
            return View();
        }

        [ActionName("search")]
        public ViewResult Search(string query)
        {
            return View();
        }
    }
}