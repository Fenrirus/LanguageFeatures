using LanguageFeatures.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Przejście do adresu pokazującego przykład";
        }

        public ViewResult AutoProperty()
        {
            Product myProduct = new Product
            {
                Name = "Kajak",
            };

            var productName = myProduct.Name;

            return View("Result", (object)String.Format($"Nazwa Produktu: {productName}"));
        }

        public ViewResult CreateProduct()
        {
            Product myProduct = new Product()
            {
                ProductId = 100,
                Name = "Kajak",
                Description = "Łódka jednoosobowa",
                Price = 275M,
                Category = "Sporty Wodne"
            };

            return View("Result", (object)String.Format($"Kategoria: {myProduct.Category}"));
        }

        public ViewResult CreateCollection()
        {
            string[] stringArray = { "jabłko", "morela", "wiśnia" };

            List<int> intList = new List<int> { 1, 2, 3, 4 };

            Dictionary<string, int> dict = new Dictionary<string, int>
            {
                {"jabłko", 10 },
                {"morela", 20 },
                {"wiśnia", 30 } ,
            };
            return View("Result", (object)stringArray[1]);
        }

        public ViewResult UseExtensionEnum()
        {
            IEnumerable<Product> shoppingCart = new ShoppingCart()
            {
                Products = new List<Product>()
                {
                    new Product { Name = "Kajak", Category = "Sporty Wodne", Price = 275M },
                    new Product { Name = "Kajak", Category = "Sporty Wodne", Price = 375M },
                    new Product { Name = "Piłka nożna", Category = "Piłka nożna", Price = 100M },
                    new Product { Name = "Piłka nożna", Category = "Piłka nożna", Price = 100M },
                }
            };

            Product[] productArray =
            {
                    new Product { Name = "Kajak", Category = "Sporty Wodne", Price = 275M },
                    new Product { Name = "Kajak", Category = "Sporty Wodne", Price = 375M },
                    new Product { Name = "Piłka nożna", Category = "Piłka nożna", Price = 100M },
                    new Product { Name = "Piłka nożna", Category = "Piłka nożna", Price = 100M },
            };

            decimal cartTotal = shoppingCart.TotalPrices();
            decimal arrayTotal = productArray.TotalPrices();
            decimal pilkaToral = 0;

            foreach (var pilka in shoppingCart.FilterByCategory("Piłka nożna"))
            {
                pilkaToral += pilka.Price;
            }

            return View("Result", (object)string.Format("Razem koszyk: {0:c}, Razem tablica: {1:c}, Razem piłka: {2:c}", cartTotal, arrayTotal, pilkaToral));
        }

        public ViewResult UseExtension()
        {
            ShoppingCart shoppingCart = new ShoppingCart()
            {
                Products = new List<Product>()
                {
                    new Product { Name = "Kajak", Price = 275M },
                    new Product { Name = "Kajak", Price = 375M },
                    new Product { Name = "Kajak", Price = 575M },
                }
            };
            decimal total = shoppingCart.TotalPrices();
            return View("Result", (object)string.Format("Razem: {0:c}", total));
        }
    }
}