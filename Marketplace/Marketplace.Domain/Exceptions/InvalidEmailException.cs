namespace Marketplace.Domain.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an invalid email address is encountered.
    /// </summary>
    public class InvalidEmailException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidEmailException"/> class with a specified error message.
        /// </summary>
        /// <param name="message"></param>
        public InvalidEmailException(string message) : base(message)
        {
        }
    }
}