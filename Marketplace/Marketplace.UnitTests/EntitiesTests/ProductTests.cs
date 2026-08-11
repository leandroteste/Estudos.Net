using Marketplace.Domain.Entities;
using Marketplace.Domain.Exceptions;
using Marketplace.Domain.ValueObjects;

namespace Marketplace.UnitTests.EntitiesTests
{
    public class ProductTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Product_Should_Throw_Exception_When_Name_Is_Null_or_Empty_or_Whitespace(string name)
        {
            // Arrange
            var productId = 1;
            var price = new Money(10, new Currency("USD", "United States Dollar"));

            // Act & Assert
            Assert.Throws<DomainArgumentException>(() =>
                new Product(productId, name, price));
        }

        [Fact]
        public void Product_Should_Throw_Exception_When_Price_Is_Null()
        {
            // Arrange
            var productId = 1;
            var name = "Test Product";

            // Act & Assert
            Assert.Throws<DomainArgumentException>(() =>
                new Product(productId, name, null));
        }

        [Fact]
        public void Product_WithSameId_ShouldBeEqual()
        {
            // Arrange
            var productId = 1;
            var name = "Test Product";
            var price = new Money(10, new Currency("USD", "United States Dollar"));

            // Act
            var product1 = new Product(productId, name, price);
            var product2 = new Product(productId, name, price);

            // Assert
            Assert.Equal(product1, product2);
        }

        [Fact]
        public void Product_WithDifferentId_ShouldNotBeEqual()
        {
            // Arrange
            var name = "Test Product";
            var price = new Money(10, new Currency("USD", "United States Dollar"));

            // Act
            var product1 = new Product(1, name, price);
            var product2 = new Product(2, name, price);
            
            // Assert
            Assert.NotEqual(product1, product2);
        }
    }
}