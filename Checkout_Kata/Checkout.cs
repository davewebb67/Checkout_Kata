using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkout_Kata
{
    public class Checkout : ICheckout
    {
        private Dictionary<string, decimal> _productList;
        private List<string> _purchasedProducts;

        public Checkout()
        {
            _productList = new Dictionary<string, decimal>()
            {
                {"A99", 0.5M},
                {"B15", 0.3M},
                {"C40", 0.6M}
            };
            _purchasedProducts = new List<string>();
        }

        public decimal GetTotal()
        {
            return _purchasedProducts.Sum(sku => GetPrice(sku));
         }

        private decimal GetPrice(string sku)
        {
            if (string.IsNullOrEmpty(sku))
            {
                return 0M;
            }
            _productList.TryGetValue(sku, out decimal price);
            return price;
        }

        public void Scan(string sku)
        {
            _purchasedProducts.Add(sku);
        }
    }
}
