using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        /*public static decimal TotalPrices(this ShoppingCart cartParam)
        {
            decimal total = 0;

            foreach (Product prod in cartParam.Products)
            {
                total += prod.Price;
            }

            return total;
        }*/

        public static decimal TotalPrices(this IEnumerable<Product> productEnum)
        {
            decimal total = 0;

            foreach (Product prod in productEnum)
            {
                total += prod.Price;
            }

            return total;
        }

        public static IEnumerable<Product> FilterByCategory(this IEnumerable<Product> productEnum, string Category)
        {
            foreach (var prod in productEnum)
            {
                if (prod.Category == Category)
                {
                    yield return prod;
                }
            }
        }
    }
}