using LanguageFeatures.Models;
using System;
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
                Name = "Kajak"
            };

            var productName = myProduct.Name;

            return View("Result", (object)String.Format($"Nazwa Produktu: {productName}"));
        }
    }
}