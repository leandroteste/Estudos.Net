using Marketplace.Domain.Common;
using Marketplace.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Marketplace.Domain.ValueObjects
{
    /// <summary>
    /// Represents an email address value object with validation.
    /// </summary>
    public class Email : ValueObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Email"/> class with the specified email address.
        /// </summary>
        /// <param name="address"></param>
        public Email(string address)
        {
            ValidateAddress(address);
            Address = address;
        }

        /// <summary>
        /// Gets the email address.
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Validates the email address format.
        /// </summary>
        /// <param name="address">The email address to validate.</param>
        /// <returns><paramref name="address"/> if valid, otherwise throws an exception.</returns>
        private static void ValidateAddress(string address)
        {
            var validEmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            var valid = !string.IsNullOrEmpty(address) && Regex.IsMatch(address, validEmailPattern);

            if (!valid)
            {
                throw new DomainArgumentException("Invalid email address.");
            }
        }

        /// <summary>
        /// Gets the components used for equality comparison.
        /// </summary>
        /// <returns>An enumerable of objects representing the equality components.</returns>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Address;
        }
    }
}