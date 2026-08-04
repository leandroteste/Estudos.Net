using Marketplace.Domain.Common;
using Marketplace.Domain.Exceptions;

namespace Marketplace.Domain.ValueObjects
{
    /// <summary>
    /// Represents a CPF (Cadastro de Pessoas Físicas) value object with validation.
    /// </summary>
    public class Cpf : ValueObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cpf"/> class with the specified CPF number.
        /// </summary>
        /// <param name="number"></param>
        public Cpf(string number)
        {
            Number = Validate(number);
        }

        /// <summary>
        /// Gets the CPF number.
        /// </summary>
        public string Number { get; }

        /// <summary>
        /// Validates the CPF number format.
        /// </summary>
        /// <returns>An enumerable of objects representing the equality components.</returns>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
        }

        /// <summary>
        /// Validates the CPF number format.
        /// </summary>
        /// <param name="number"></param>
        /// <returns><see cref="string"/></returns>      
        /// <exception cref="DomainArgumentException"></exception>
        private static string Validate(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new DomainArgumentException("CPF cannot be null or empty.");
            }

            return number;
        }
    }
}
