using Marketplace.Domain.Exceptions;
using Marketplace.Domain.ValueObjects;

namespace Marketplace.UnitTests.ValueObjectsTests
{
    public class MoneyTests
    {
        [Fact]
        public void Money_Should_Throw_DomainArgumentException_When_Amount_Is_Negative()
        {
            // Arrange
            decimal negativeAmount = -10m;
            var currency = new Currency("USD", "United States Dollar");
            
            // Act & Assert
            var exception = Assert.Throws<DomainArgumentException>(() => new Money(negativeAmount, currency));
            Assert.Equal("Amount cannot be negative.", exception.Message);
        }

        [Fact]
        public void Money_Should_Throw_DomainArgumentException_When_Currency_Is_Null()
        {
            // Arrange
            decimal amount = 10m;
            Currency nullCurrency = null;
            // Act & Assert
            var exception = Assert.Throws<DomainArgumentException>(() => new Money(amount, nullCurrency));
            Assert.Equal("Currency cannot be null.", exception.Message);
        }
        
        [Fact]
        public void Money_With_Valid_Amount_And_Currency_Should_Be_Created_Successfully()
        {
            // Arrange
            decimal amount = 10m;
            var currency = new Currency("USD", "United States Dollar");

            // Act
            var money = new Money(amount, currency);

            // Assert
            Assert.Equal(amount, money.Amount);
            Assert.Equal(currency, money.Currency);
        }

        [Fact]
        public void Money_With_Same_Amount_And_Currency_Should_Be_Equal()
        {
            // Arrange
            decimal amount = 10m;
            var currency = new Currency("USD", "US Dollar");
            var currency2 = new Currency("USD", "United States Dollar");
            
            var money1 = new Money(amount, currency);
            var money2 = new Money(amount, currency2);

            // Act
            bool result = money1.Equals(money2);
            
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Money_With_Different_Amount_Should_Not_Be_Equal()
        {
            // Arrange
            var currency = new Currency("USD", "United States Dollar");

            var money1 = new Money(10m, currency);
            var money2 = new Money(20m, currency);
            
            // Act
            bool result = money1.Equals(money2);
            
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Money_With_Different_Currency_Should_Not_Be_Equal()
        {
            // Arrange
            var currency1 = new Currency("USD", "United States Dollar");
            var currency2 = new Currency("EUR", "Euro");
            var money1 = new Money(10m, currency1);
            var money2 = new Money(10m, currency2);

            // Act
            bool result = money1.Equals(money2);

            // Assert
            Assert.False(result);
        }
    }
}