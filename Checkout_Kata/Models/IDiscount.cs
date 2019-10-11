namespace Checkout_Kata
{
    public interface IDiscount
    {
        string Sku { get; set; }
        int Quantity{get;set;}
        decimal AmountDiscounted { get; set; } 
    }
}