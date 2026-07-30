using Marketplace.Domain.Exceptions;
using Marketplace.Domain.ValueObjects;

namespace Marketplace.UnitTests.ValueObjectsTests
{
    public class EmailTests
    {
        [Fact]
        public void IsValidAddress_Returns_Valid_Address()
        {
            var email = new Email("teste@teste.com");
            Assert.Equal("teste@teste.com", email.Address);
        }

        [Fact]
        public void IsValidAddress_Throws_Exception_For_Invalid_Address()
        {
            Assert.Throws<DomainArgumentException>(() => new Email("invalid-email"));
        }

        [Fact]
        public void IsValidAddress_Throws_Exception_For_Empty_Address()
        {
            Assert.Throws<DomainArgumentException>(() => new Email(""));
        }

        [Fact]
        public void IsValidAddress_Throws_Exception_For_Null_Address()
        {
            Assert.Throws<DomainArgumentException>(() => new Email(null));
        }

        [Fact]
        public void IsValidAddress_Throws_Exception_For_Address_Without_Domain()
        {
            Assert.Throws<DomainArgumentException>(() => new Email("com.user@teste"));
        }
    }
}