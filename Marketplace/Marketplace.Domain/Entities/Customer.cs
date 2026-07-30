using Marketplace.Domain.Common;
using Marketplace.Domain.Exceptions;
using Marketplace.Domain.ValueObjects;

namespace Marketplace.Domain.Entities
{
    /// <summary>
    /// Represents a customer entity in the domain model.
    /// </summary>
    public class Customer : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class with the specified ID, name, and email address.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        public Customer(int id, string name, Email email) : base(id)
        {
            ValidateName(name);

            Id = id;
            Name = name;
            Email = email;
        }

        /// <summary>
        /// Gets the name of the customer.
        /// </summary>
        public string Name { get; private set; }

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
                throw new DomainArgumentException("Name cannot be null or empty.");
            }
        }
    }
}