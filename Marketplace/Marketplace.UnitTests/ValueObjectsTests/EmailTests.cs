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

        [Fact]
        public void TwoEmails_WithSameAddress_ShouldBeEqual()
        {
            var email = new Email("teste@teste.com");
            var email2 = new Email("teste@teste.com");
            Assert.Equal(email, email2);
        }

        [Fact]
        public void TwoEmails_WithDifferentAddresses_ShouldNotBeEqual()
        {
            var email1 = new Email("primeiro@teste.com");
            var email2 = new Email("segundo@teste.com");

            Assert.NotEqual(email1, email2);
        }

        [Fact]
        public void HashSet_ShouldNotAddDuplicateEmail()
        {
            var emails = new HashSet<Email>
            {
                new("teste@teste.com"),
                new("teste@teste.com")
            };

            Assert.Single(emails);
        }
    }
}