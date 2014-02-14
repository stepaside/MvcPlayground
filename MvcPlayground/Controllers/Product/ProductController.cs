using MvcPlayground.Models.Customer;
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
            SetupModuleModel("ProductDetail", new { Product = model });
            SetupModuleModel("ProductOfTheDay", new { Product = model, Customer = new Customer { Name = "Customer 1" } });
            return CitkaView();
        }

        [ActionName("search")]
        public ViewResult Search(string query)
        {
            var products = Enumerable.Range(1, 10).Select(i => DataManager.GetProduct(i));
            SetupModuleModel("ProductSearch", products);
            return CitkaView();
        }
    }
}