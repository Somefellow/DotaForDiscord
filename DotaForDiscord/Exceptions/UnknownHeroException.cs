using System;
using System.Runtime.Serialization;

namespace DotaForDiscord.Exceptions
{
    [Serializable]
    internal class UnknownHeroException : Exception
    {
        public UnknownHeroException()
        {
        }

        public UnknownHeroException(int id) : base("Unknown Hero ID - " + id)
        {
        }

        public UnknownHeroException(string message) : base(message)
        {
        }

        public UnknownHeroException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnknownHeroException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}