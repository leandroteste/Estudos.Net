using Marketplace.Domain.Exceptions;
using Marketplace.Domain.ValueObjects;

namespace Marketplace.Domain.Entities
{
    /// <summary>
    /// Represents a customer entity with an ID, name, and email address.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class with the specified ID, name, and email address.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        public Customer(int id, string name, Email email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        /// <summary>
        /// Gets the unique identifier of the customer.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets the name of the customer.
        /// </summary>
        public string Name
        {
            get;
            private set
            {
                ValidateName(value);
                field = value;
            }
        }

        /// <summary>
        /// Gets the email address of the customer.
        /// </summary>
        public Email Email { get; private set; }

        /// <summary>
        /// Validates the name of the customer.
        /// </summary>
        /// <param name="name">The name to validate.</param>
        /// <exception cref="CustomerException"></exception>
        private static void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new CustomerException("Name cannot be null or empty.");
            }
        }
    }
}