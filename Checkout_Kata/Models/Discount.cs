namespace Checkout_Kata.Models
{
    public class Discount : IDiscount
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public decimal AmountDiscounted { get; set; }
    }
}
