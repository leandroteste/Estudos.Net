namespace Marketplace.Domain.Exceptions
{
    public class DomainArgumentException : ArgumentException
    {
        public DomainArgumentException(string message) : base(message)
        {
        }
    }
}
