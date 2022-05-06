using System.Runtime.Serialization;
using System;

namespace Project.Command.Domain.Exceptions
{
    [Serializable]
    public class DomainException : Exception
    {
        public DomainException() { }
        public DomainException(string message) : base(message)
        {
        }
        public DomainException(string message, Exception innerException)
          : base(message, innerException)
        {
        }

        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
