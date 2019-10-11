using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout_Kata
{
    public interface ICheckout
    {
        decimal GetTotal();
        void Scan(string sku);
    }
}
