using System;
using System.Runtime.Serialization;

namespace Project.Command.Domain.Exceptions
{
    [Serializable]
    public class ConcurrencyException : DomainException
    {
        public ConcurrencyException() { }
        public ConcurrencyException(string message) : base(message)
        {
        }
        public ConcurrencyException(string message, Exception innerException)
          : base(message, innerException)
        {
        }

        protected ConcurrencyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
