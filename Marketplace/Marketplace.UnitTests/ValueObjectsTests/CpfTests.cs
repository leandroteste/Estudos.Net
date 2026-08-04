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

        [Fact]
        public void TwoCpfs_WithSameNumber_ShouldBeEqual()
        {
            var cpf = new Cpf("12345678901");
            var cpf2 = new Cpf("12345678901");
            Assert.Equal(cpf, cpf2);
        }

        [Fact]
        public void TwoCpfs_WithDifferentNumbers_ShouldNotBeEqual()
        {
            var cpf1 = new Cpf("12345678901");
            var cpf2 = new Cpf("98765432100");

            Assert.NotEqual(cpf1, cpf2);
        }

        [Fact]
        public void HashSet_ShouldNotAddDuplicateCpf()
        {
            var cpfs = new HashSet<Cpf>
            {
                new("12345678901"),
                new("12345678901")
            };

            Assert.Single(cpfs);
        }

    }
}
