using System.Collections.Generic;
using System.Linq;
using Checkout_Kata.Models;

namespace Checkout_Kata
{
    public class Checkout : ICheckout
    {
        private IEnumerable<IItem> _productList;
        private List<string> _purchasedProducts;
        private IEnumerable<IDiscount> _discounts;

        public Checkout(IEnumerable<IItem> productList, IEnumerable<IDiscount> discounts)
        {
            _productList = productList;

            _purchasedProducts = new List<string>();
            _discounts = discounts;
        }

        public decimal GetTotal()
        {
            var total = 0M;
            total =  _purchasedProducts.Sum(sku => GetPrice(sku));

            var discountTotal = _discounts.Sum(discount => GetDiscountAmount(discount)); 

            return total - discountTotal;
         }

        private decimal GetDiscountAmount(IDiscount discount)
        {
            var amountDiscounted = (_purchasedProducts.Count(x => x == discount.Sku) / discount.Quantity) * discount.AmountDiscounted;
            return amountDiscounted;
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
