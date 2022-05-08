using System;
using System.Runtime.Serialization;

namespace Project.Command.Application.Common.Exceptions
{
    [Serializable]
    public class ArgumentNullApplicationException : ApplicationException
    {
        public ArgumentNullApplicationException() { }
        public ArgumentNullApplicationException(string message) : base(message)
        {
        }
        public ArgumentNullApplicationException(string message, Exception innerException)
          : base(message, innerException)
        {
        }

        protected ArgumentNullApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
