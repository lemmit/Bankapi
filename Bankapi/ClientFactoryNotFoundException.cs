using System;
using System.Runtime.Serialization;

namespace Bankapi
{
    [Serializable]
    public class ClientFactoryNotFoundException : Exception
    {
        public ClientFactoryNotFoundException()
        {
        }

        public ClientFactoryNotFoundException(string message) : base(message)
        {
        }

        public ClientFactoryNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClientFactoryNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}