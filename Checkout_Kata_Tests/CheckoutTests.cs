using System;
using Checkout_Kata;
using Xunit;

namespace Checkout_Kata_Tests
{
    public class CheckoutTests
    {
        private ICheckout _sut;

        public CheckoutTests()
        {
            _sut = new Checkout();
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
    }
}
