using System;

namespace Bankapi.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException(string message) : base(message)
        {
        }
    }
}