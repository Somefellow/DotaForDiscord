using System;
using System.Runtime.Serialization;

namespace DotaForDiscord.Exceptions
{
    [Serializable]
    internal class NotTrackedException : Exception
    {
        public NotTrackedException()
        {
        }

        public NotTrackedException(int id) : base("Untracked Player ID - " + id)
        {
        }

        public NotTrackedException(string message) : base(message)
        {
        }

        public NotTrackedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotTrackedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}