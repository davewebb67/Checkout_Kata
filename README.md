Developer - Checkout Kata
Problem Synopsis
A supermarket requires a working checkout. MVP is to scan products and periodically ask for a total price, considering any special offers that apply to the product.
Items:
SKUUnit PriceA990.50B150.30C400.60Special Offers:
SKUQuantityOffer PriceA9931.30B1520.45The checkout accepts items scanned in any order, so that if we scan a pack of Biscuits (B15), an apple (A99) and another pack of biscuits, we�ll recognise two packs of biscuits and apply the discount of 2 for 45. Prove your solution works for this scenario.
1. Check that when no items are scanned the total returned is 0.0;

