using Marketplace.Domain.Common;
using Marketplace.Domain.Exceptions;

namespace Marketplace.Domain.ValueObjects
{
    /// <summary>
    /// Represents a currency value object in the domain model.
    /// </summary>
    public class Money : ValueObject
    {
        /// <summary>
        /// Gets the amount of money.
        /// </summary>
        public decimal Amount { get; }

        /// <summary>
        /// Gets the currency of the money.
        /// </summary>
        public Currency Currency { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> class with the specified amount and currency.
        /// </summary>
        /// <param name="amount">The amount of money.</param>
        /// <param name="currency">The currency of the money.</param>
        public Money(decimal amount, Currency currency)
        {
            ValidateAmount(amount);
            ValidateCurrency(currency);

            Amount = amount;
            Currency = currency;
        }

        /// <summary>
        /// Validates the amount of money.
        /// </summary>
        /// <param name="amount">The amount of money.</param>
        /// <exception cref="DomainArgumentException"></exception>
        private static void ValidateAmount(decimal amount)
        {
            if (amount < 0)
            {
                throw new DomainArgumentException("Amount cannot be negative.");
            }
        }

        /// <summary>
        /// Validates the currency of the money.
        /// </summary>
        /// <param name="currency">The currency of the money.</param>
        /// <exception cref="DomainArgumentException"></exception>
        private static void ValidateCurrency(Currency currency)
        {
            if (currency == null)
            {
                throw new DomainArgumentException("Currency cannot be null.");
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}