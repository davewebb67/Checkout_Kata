namespace Checkout_Kata
{
    internal interface IDiscount
    {
        string Sku { get; set; }
        int Quantity{get;set;}
        decimal AmountDiscounted { get; set; } 
    }
}