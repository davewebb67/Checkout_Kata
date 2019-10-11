using System;

namespace Checkout_Kata
{
    public class Checkout : ICheckout
    {
        private string _sku;

        public decimal GetTotal()
        {
            switch (_sku)
            {
                case "A99":
                    return 0.5M;
                case "B15":
                    return 0.3M;
                case "C40":
                    return 0.6M;
                    default:
                    return 0M;
            }
        }

        public void Scan(string sku)
        {
            _sku = sku;
        }
    }
}
