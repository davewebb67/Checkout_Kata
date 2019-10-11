using System;
using System.Collections.Generic;
using System.Linq;
using Checkout_Kata.Models;

namespace Checkout_Kata
{
    public class Checkout : ICheckout
    {
        private IEnumerable<IItem> _productList;
        private List<string> _purchasedProducts;

        public Checkout(IEnumerable<IItem> productList)
        {
            _productList = productList;
            _purchasedProducts = new List<string>();
        }

        public decimal GetTotal()
        {
            return _purchasedProducts.Sum(sku => GetPrice(sku));
         }

        private decimal GetPrice(string sku)
        {
            var price = _productList.Single(x => x.Sku == sku).Price;
            return price;
        }

        public void Scan(string sku)
        {
            if(_productList.Any(x=>x.Sku == sku))
                _purchasedProducts.Add(sku);
        }
    }
}
