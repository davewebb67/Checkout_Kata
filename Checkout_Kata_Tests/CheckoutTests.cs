using System.Collections.Generic;
using System.Linq;
using Checkout_Kata;
using Checkout_Kata.Models;
using Xunit;

namespace Checkout_Kata_Tests
{
    public class CheckoutTests
    {
        private ICheckout _sut;

        public CheckoutTests()
        {
            IEnumerable<IItem> productList = new[]
            {
                new Item{Sku = "A99", Price = 0.5M},
                new Item{Sku = "B15", Price = 0.3M},
                new Item{Sku = "C40", Price = 0.6M}
            };

            IEnumerable<IDiscount> discounts = new[]
            {
                new Discount{ Sku="A99", Quantity = 3, AmountDiscounted = 0.2M},
                new Discount{ Sku="B15", Quantity = 2, AmountDiscounted = 0.15M},
            };

            _sut = new Checkout(productList, discounts);
        }

        [Fact]
        public void When_No_Items_Are_Scanned_Should_Return_0()
        {
            // Arrange
            decimal expected = 0;

            // Act
            var result = _sut.GetTotal();

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("A99", 0.5)]
        [InlineData("B15", 0.3)]
        [InlineData("C40", 0.6)]
        public void When_A_Single_Item_Is_Scanned_The_Expected_Total_Should_Be_Returned(string sku, decimal expected)
        {
            // Act
            _sut.Scan(sku);
            var result = _sut.GetTotal();

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("bla")]
        public void Should_Ignore_An_Invalid_Sku(string sku)
        {
            // Arrange
            var expected = 0M;
            // Act
            _sut.Scan(sku);
            var result = _sut.GetTotal();

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, "A99", "A99")]
        [InlineData(0.8, "B15", "A99")]
        [InlineData(1.3, "B15", "A99", "A99")]
        [InlineData(1.2, "C40", "C40")]
        public void When_Multiple_Items_Are_Scanned_Without_Special_Offers_Applied_Total_Should_Be_As_Expected(decimal expected, params string[] skus)
        {
            //Act
            skus.ToList().ForEach(x => _sut.Scan(x));
            var result = _sut.GetTotal();

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1.30, "A99", "A99", "A99")]
        [InlineData(0.45, "B15","B15")]
        [InlineData(1.80, "A99", "A99", "A99", "A99")]
        [InlineData(0.75, "B15", "B15", "B15")]
        [InlineData(0.95, "B15", "A99", "B15")]
        public void When_Multiple_Items_Are_Scanned_Which_Trigger_Special_Offers_Applied_Total_Should_Be_As_Expected(decimal expected, params string[] skus)
        {
            //Act
            skus.ToList().ForEach(x => _sut.Scan(x));
            var result = _sut.GetTotal();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
