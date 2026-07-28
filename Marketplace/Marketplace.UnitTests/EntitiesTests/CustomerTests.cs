using Marketplace.Domain.Entities;
using Marketplace.Domain.Exceptions;
using Marketplace.Domain.ValueObjects;

namespace Marketplace.UnitTests.EntitiesTests
{
    public class CustomerTests
    {
        [Fact]
        public void CreateCustomer_WithValidData_ShouldSucceed()
        {
            // Arrange
            int id = 1;
            string name = "John Doe";
            var email = new Email("john.doe@teste.com");

            // Act
            var customer = new Customer(id, name, email);

            // Assert
            Assert.Equal(id, customer.Id);
            Assert.Equal(name, customer.Name);
            Assert.Equal(email, customer.Email);
        }

        [Fact]
        public void CreateCustomer_WithEmptyName_ShouldThrowException()
        {
            // Arrange
            int id = 1;
            string name = "";
            var email = new Email("john.doe@teste.com");

            // Act & Assert
            Assert.Throws<CustomerException>(() => new Customer(id, name, email));
        }

        [Fact]
        public void CreateCustomer_WithNullName_ShouldThrowException()
        {
            // Arrange
            int id = 1;
            string name = null;
            var email = new Email("john.doe@teste.com");

            // Act & Assert
            Assert.Throws<CustomerException>(() => new Customer(id, name, email));
        }
    }
}