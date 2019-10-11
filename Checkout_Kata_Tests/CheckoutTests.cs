using System;
using Checkout_Kata;
using Xunit;

namespace Checkout_Kata_Tests
{
    public class CheckoutTests
    {
        [Fact]
        public void When_No_Items_Are_Scanned_Should_Return_0()
        {
            // Arrange
            var sut = new Checkout();
            decimal expected = 0;

            // Act
            var result = sut.GetTotal();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
