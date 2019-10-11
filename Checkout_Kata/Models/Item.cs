namespace Checkout_Kata.Models
{
    public class Item : IItem
    {
        public string Sku { get; set; }
        public decimal Price { get; set; }
    }
}
