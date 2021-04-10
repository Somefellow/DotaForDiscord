using System;
using System.Runtime.Serialization;

namespace DotaForDiscord.Exceptions
{
    [Serializable]
    internal class BadGatewayException : Exception
    {
        public BadGatewayException() : base("Bad Gateway - Bad Gateway Response from CloudFlare.")
        {
        }

        public BadGatewayException(string message) : base(message)
        {
        }

        public BadGatewayException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BadGatewayException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}