using Marketplace.Domain.Exceptions;
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
        public int Id { get; }

        /// <summary>
        /// Gets or sets the unique identifier of the entity.
        /// </summary>
        /// <param name="id"></param>
        protected Entity(int id)
        {
            if (id <= 0)
            {
                throw new DomainArgumentException("Id must be greater than zero.");
            }


            Id = id;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current entity.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns><see cref="bool"/></returns>
        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (Entity)obj;

            return Id == other.Id;
        }

        /// <summary>
        /// Returns a hash code for the current entity.
        /// </summary>
        /// <returns><see cref="int"/></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(GetType(), Id);
        }
    }
}