using Marketplace.Domain.Exceptions;

namespace Marketplace.Domain.ValueObjects
{
    /// <summary>
    /// Represents a CPF (Cadastro de Pessoas Físicas) value object with validation.
    /// </summary>
    public class Cpf
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cpf"/> class with the specified CPF number.
        /// </summary>
        /// <param name="number"></param>
        public Cpf(string number)
        {
            Validate(number);
            Number = number;
        }

        /// <summary>
        /// Gets the CPF number.
        /// </summary>
        public string Number { get; private set; }

        /// <summary>
        /// Validates the CPF number format.
        /// </summary>
        /// <param name="number"></param>
        /// <exception cref="DomainArgumentException"></exception>
        private void Validate(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new DomainArgumentException ("CPF cannot be null or empty.");
            }
        }
    }
}
