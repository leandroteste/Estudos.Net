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
            Assert.Throws<DomainArgumentException>(() => new Customer(id, name, email));
        }

        [Fact]
        public void CreateCustomer_WithNullName_ShouldThrowException()
        {
            // Arrange
            int id = 1;
            string name = null;
            var email = new Email("john.doe@teste.com");

            // Act & Assert
            Assert.Throws<DomainArgumentException>(() => new Customer(id, name, email));
        }

        [Fact]
        public void Customer_WithSameId_ShouldBeEqual()
        {
            var customer1 = new Customer(1, "John Doe", new Email("john.doe@teste.com"));
            var customer2 = new Customer(1, "Jane Doe", new Email("jane.doe@teste.com"));

            Assert.Equal(customer1, customer2);
        }

        [Fact]
        public void Customer_WithDifferentId_ShouldNotBeEqual()
        {
            var customer1 = new Customer(1, "John Doe", new Email("john.doe@teste.com"));
            var customer2 = new Customer(2, "John Doe", new Email("john.doe@teste.com"));

            Assert.NotEqual(customer1, customer2);
        }

        [Fact]
        public void HashSet_ShouldNotAddCustomersWithSameId()
        {
            var customers = new HashSet<Customer>
            {
                new(1,"Leandro",new Email("leandro@teste.com")),
                new(1,"Outro nome",new Email("outro@teste.com"))
            };

            Assert.Single(customers);
        }
    }
}