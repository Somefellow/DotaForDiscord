using System;
using System.Runtime.Serialization;

namespace DotaForDiscord.Exceptions
{
    [Serializable]
    internal class DeserializationException : Exception
    {
        public DeserializationException()
        {
        }

        public DeserializationException(string message) : base(message)
        {
        }

        public DeserializationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DeserializationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}