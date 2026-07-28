namespace Marketplace.Domain.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when a customer-related error occurs.
    /// </summary>
    public class CustomerException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerException"/> class with a specified error message.
        /// </summary>
        /// <param name="message"></param>
        public CustomerException(string message) : base(message)
        {
        }
    }
}