using Marketplace.Domain.Common;
using Marketplace.Domain.Exceptions;
using Marketplace.Domain.ValueObjects;

namespace Marketplace.Domain.Entities
{
    /// <summary>
    /// Represents a product entity in the domain model.
    /// </summary>
    public class Product : Entity
    {
        /// <summary>
        /// Gets the name of the product.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the price of the product.
        /// </summary>
        public Money Price { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with the specified ID, name, and price.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <param name="name">The name of the product.</param>
        /// <param name="price">The price of the product.</param>
        public Product(int id, string name, Money price) : base(id)
        {
            ValidateName(name);
            ValidatePrice(price);

            Name = name;
            Price = price;
        }

        /// <summary>
        /// Validates the name of the product.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <exception cref="DomainArgumentException"></exception>
        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainArgumentException("Product name cannot be null or empty.");
            }
        }

        /// <summary>
        /// Validates the price of the product.
        /// </summary>
        /// <param name="price">The price of the product.</param>
        /// <exception cref="DomainArgumentException"></exception>
        private void ValidatePrice(Money price)
        {
            if (price == null)
            {
                throw new DomainArgumentException("Product price cannot be null.");
            }
        }
    }
}