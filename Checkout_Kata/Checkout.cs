using System;
using System.Collections.Generic;

namespace Checkout_Kata
{
    public class Checkout : ICheckout
    {
        private string _sku;
        private Dictionary<string, decimal> _productList;

        public Checkout()
        {
            _productList = new Dictionary<string, decimal>()
            {
                {"A99", 0.5M},
                {"B15", 0.3M},
                {"C40", 0.6M}
            };
        }

        public decimal GetTotal()
        {
            if(string.IsNullOrEmpty(_sku))
            {
                return 0M;
            }

            _productList.TryGetValue(_sku, out decimal price);
            return price;
         }

        public void Scan(string sku)
        {
            _sku = sku;
        }
    }
}
