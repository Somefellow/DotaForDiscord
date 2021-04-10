using System;
using System.Runtime.Serialization;

namespace DotaForDiscord.Exceptions
{
    [Serializable]
    internal class TooManyRequestsException : Exception
    {
        public TooManyRequestsException() : base("Too many requests - API being throttled by CloudFlare.")
        {
        }

        public TooManyRequestsException(string message) : base(message)
        {
        }

        public TooManyRequestsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TooManyRequestsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}