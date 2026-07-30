using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Domain.Common
{
    /// <summary>
    /// Represents a base entity class with an ID property.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the entity.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Gets or sets the unique identifier of the entity.
        /// </summary>
        /// <param name="id"></param>
        protected Entity(int id)
        {
            Id = id;
        }
    }
}