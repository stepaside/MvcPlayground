using MvcPlayground.Models.Framework;
using MvcPlayground.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MvcPlayground
{
    public class DataManager
    {
        private static string GetLatestVersion(string appCode)
        {
            return "3.5";
        }

        private static string GetApplicationCodeByDomain(string domain)
        {
            return "APPL";
        }

        public static Application GetApplication(string domain)
        {
            var appCode = GetApplicationCodeByDomain(domain);
            return GetApplication(appCode, GetLatestVersion(appCode));
        }

        public static Application GetApplication(string appCode, string appVersion)
        {
            var app = new Application { ApplicationId = 1, Code = appCode, Version = appVersion ?? GetLatestVersion(appCode), Domain = "localhost" };
            app.Pages = new List<Page> { 
                new Page { PageId = 1 , ApplicationId = 1, Name = "home", LayoutId = 10 },
                new Page { PageId = 2 , ApplicationId = 1, Name = "product", LayoutId = 10 },
                new Page { PageId = 3 , ApplicationId = 1, Name = "supplier", LayoutId = 10 },
                new Page { PageId = 4 , ApplicationId = 1, Name = "product/search", LayoutId = 10 },
            };
            return app;
        }

        public static List<ModuleInstance> LoadInstances(int pageId)
        {
            if (pageId == 1)
            {
                return new List<ModuleInstance> { 
                    new ModuleInstance { Index = 0, InstanceId = 110, Zone = "Header", Module = new Module { ModuleId = 101, Name = "Header" } },
                    new ModuleInstance { Index = 0, InstanceId = 140, Zone = "Main", Module = new Module { ModuleId = 111, Name = "TopSellers" } },
                    new ModuleInstance { Index = 1, InstanceId = 120, Zone = "Main", Module = new Module { ModuleId = 113, Name = "EventViewer" } },
                    new ModuleInstance { Index = 1, InstanceId = 150, Zone = "Main", Module = new Module { ModuleId = 115, Name = "News" } },
                    new ModuleInstance { Index = 0, InstanceId = 130, Zone = "Footer", Module = new Module { ModuleId = 107, Name = "Footer" } }
                };
            }
            else if (pageId == 2)
            {
                return new List<ModuleInstance> { 
                    new ModuleInstance { Index = 0, InstanceId = 210, Zone = "Header", Module = new Module { ModuleId = 101, Name = "Header" } },
                    new ModuleInstance { Index = 1, InstanceId = 240, Zone = "Main", Module = new Module { ModuleId = 103, Name = "ProductOfTheDay" } },
                    new ModuleInstance { Index = 0, InstanceId = 220, Zone = "Main", Module = new Module { ModuleId = 105, Name = "ProductDetail" } },
                    new ModuleInstance { Index = 0, InstanceId = 230, Zone = "Footer", Module = new Module { ModuleId = 107, Name = "Footer" } }
                };
            }
            else if (pageId == 3)
            {
                return new List<ModuleInstance> { 
                    new ModuleInstance { Index = 0, InstanceId = 310, Zone = "Header", Module = new Module { ModuleId = 101, Name = "Header" } },
                    new ModuleInstance { Index = 0, InstanceId = 320, Zone = "Main", Module = new Module { ModuleId = 109, Name = "SupplierDetail" } },
                    new ModuleInstance { Index = 0, InstanceId = 330, Zone = "Footer", Module = new Module { ModuleId = 107, Name = "Footer" } }
                };
            }
            else if (pageId == 4)
            {
                return new List<ModuleInstance> { 
                    new ModuleInstance { Index = 0, InstanceId = 410, Zone = "Header", Module = new Module { ModuleId = 101, Name = "Header" } },
                    new ModuleInstance { Index = 1, InstanceId = 440, Zone = "Main", Module = new Module { ModuleId = 103, Name = "ProductOfTheDay" } },
                    new ModuleInstance { Index = 0, InstanceId = 420, Zone = "Main", Module = new Module { ModuleId = 117, Name = "ProductSearch" } },
                    new ModuleInstance { Index = 0, InstanceId = 430, Zone = "Footer", Module = new Module { ModuleId = 107, Name = "Footer" } }
                };
            }
            return new List<ModuleInstance>();
        }

        public static Product GetProduct(int productId)
        {
            var random = new Random();
            var prices = new List<Price>();
            for (int i = 1; i <= 8; i++)
            {
                var quantity = random.Next((i - 1) * 100, i * 100);
	            var value = new Decimal(random.NextDouble() + (9 - i));
                var price = new Price { Quantity = i, Value = value };
                prices.Add(price);
            }
            var product = new Product { ProductId = productId, Name = "Product-" + GetRandomString(4), Prices = prices };
            return product;
        }

        private static Random random = new Random((int)DateTime.Now.Ticks);
        private static string GetRandomString(int size)
        {
            var builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        public static Layout GetLayout(int layoutId)
        {
            var layout = new Layout
            {
                LayoutId = layoutId,
                Name = "Default",
                Source = "~/Views/Shared/MainLayout.cshtml",
                Zones = new List<Zone> 
                { 
                    new Zone { LayoutId = layoutId, Name = "Header" },
                    new Zone { LayoutId = layoutId, Name = "Main" },
                    new Zone { LayoutId = layoutId, Name = "Footer" },
                }
            };
            return layout;
        }
    }
}