using System;

namespace Infrastructure.Infrastructure
{
    public class ValidationException : Exception
    {
        public ValidationException(string message)
            : base(message)
        {

        }
    }
}
