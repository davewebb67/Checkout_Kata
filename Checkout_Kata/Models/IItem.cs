namespace Checkout_Kata.Models
{
    public interface IItem
    {
        string Sku { get; set; }
        decimal Price { get; set; }
    }
}
