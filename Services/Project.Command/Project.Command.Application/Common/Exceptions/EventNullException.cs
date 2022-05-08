using System;
using System.Runtime.Serialization;

namespace Project.Command.Application.Common.Exceptions
{
    [Serializable]
    public class EventNullException : ArgumentNullApplicationException
    {
        public EventNullException() { }
        public EventNullException(string message) : base(message)
        {
        }
        public EventNullException(string message, Exception innerException)
          : base(message, innerException)
        {
        }

        protected EventNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
