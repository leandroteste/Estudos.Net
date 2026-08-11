using Marketplace.Domain.Exceptions;
using Marketplace.Domain.ValueObjects;

namespace Marketplace.UnitTests.ValueObjectsTests
{
    public class CurrencyTests
    {
        [Fact]
        public void Currency_ShouldThrowDomainArgumentException_WhenCodeIsNullOrEmpty()
        {
            // Arrange
            string code = null;
            string fullName = "US Dollar";

            // Act & Assert
            var exception = Assert.Throws<DomainArgumentException>(() => new Currency(code, fullName));
            Assert.Equal("Currency code cannot be null or empty.", exception.Message);
        }

        [Fact]
        public void Currency_ShouldThrowDomainArgumentException_WhenFullNameIsNullOrEmpty()
        {
            // Arrange
            string code = "USD";
            string fullName = null;

            // Act & Assert
            var exception = Assert.Throws<DomainArgumentException>(() => new Currency(code, fullName));
            Assert.Equal("Currency full name cannot be null or empty.", exception.Message);
        }

        [Fact]
        public void Currency_WithSameCodeAndDifferentFullName_ShouldBeEqual()
        {
            // Arrange
            var currency1 = new Currency("USD", "US Dollar");
            var currency2 = new Currency("USD", "United States Dollar");

            // Act
            bool result = currency1.Equals(currency2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Currency_WithDifferentCode_ShouldNotBeEqual()
        {
            // Arrange
            var currency1 = new Currency("USD", "US Dollar");
            var currency2 = new Currency("EUR", "US Dollar");

            // Act
            bool result = currency1.Equals(currency2);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("US")]
        [InlineData("USDA")]
        [InlineData("U")]
        [InlineData("@SA")]
        [InlineData("A@A")]
        public void Currency_ShouldThrowDomainArgumentException_WhenCodeIsNotValid( string code)
        {
            // Arrange
            string fullName = "US Dollar";
            
            // Act
            var exception = Assert.Throws<DomainArgumentException>(() => new Currency(code, fullName));

            // Assert
            Assert.Equal("Currency code must be exactly 3 characters long and start with an uppercase letter.", exception.Message);
        }

        [Theory]
        [InlineData("usd")]
        [InlineData("UsD")]
        [InlineData("uSD")]
        [InlineData("usD")]
        public void Currency_WithLowercaseCode_ShouldBeConvertedToUppercase(string code)
        {
            // Arrange
            string fullName = "US Dollar";
            // Act
            var currency = new Currency(code, fullName);
            // Assert
            Assert.Equal(code.ToUpperInvariant(), currency.Code);
        }
    }
}