using System;

namespace Ae.Steam.Client.Exceptions
{
    public class SteamClientException : Exception
    {
        public SteamClientException(string message) : base(message)
        {
        }

        public SteamClientException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
