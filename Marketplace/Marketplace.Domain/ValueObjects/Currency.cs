using Marketplace.Domain.Common;
using Marketplace.Domain.Exceptions;

namespace Marketplace.Domain.ValueObjects
{
    /// <summary>
    /// Represents a currency value object in the domain model.
    /// </summary>
    public class Currency : ValueObject
    {
        /// <summary>
        /// Gets the currency code (e.g., USD, EUR).
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Gets the full name of the currency (e.g., United States Dollar, Euro).
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> class with the specified code and full name.
        /// </summary>
        /// <param name="code">The currency code.</param>
        /// <param name="fullName">The full name of the currency.</param>
        public Currency(string code, string fullName)
        {
            ValidateCurrencyCode(code);
            ValidateCurrencyFullName(fullName);

            Code = code.ToUpperInvariant();
            FullName = fullName;
        }

        /// <summary>
        /// Validates the currency code.
        /// </summary>
        /// <param name="code">The currency code.</param>
        /// <exception cref="DomainArgumentException"></exception>
        private static void ValidateCurrencyCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new DomainArgumentException("Currency code cannot be null or empty.");
            }

            var codebase = code.ToUpperInvariant();
            var codePattern = @"^[A-Z]{3}$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(codebase, codePattern))
            {
                throw new DomainArgumentException("Currency code must contain exactly 3 letters.");
            }
        }

        /// <summary>
        /// Validates the full name of the currency.
        /// </summary>
        /// <param name="fullName">The full name of the currency.</param>
        /// <exception cref="DomainArgumentException"></exception>
        private static void ValidateCurrencyFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new DomainArgumentException("Currency full name cannot be null or empty.");
            }
        }


        /// <summary>
        /// Creates a new instance of the <see cref="Currency"/> class.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }
    }
}