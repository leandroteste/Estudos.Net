using Marketplace.Domain.Exceptions;
using Marketplace.Domain.ValueObjects;

namespace Marketplace.UnitTests.ValueObjectsTests
{
    public class CpfTests
    {
        [Fact]
        public void IsValidCpf_Returns_Valid_Cpf()
        {
            var cpf = new Cpf("12345678901");
            Assert.Equal("12345678901", cpf.Number);
        }

        [Fact]
        public void IsValidCpf_Throws_Exception_For_Empty_Cpf()
        {
            Assert.Throws<DomainArgumentException>(() => new Cpf(""));
        }

        [Fact]
        public void IsValidCpf_Throws_Exception_For_Null_Cpf()
        {
            Assert.Throws<DomainArgumentException>(() => new Cpf(null));
        }
    }
}
