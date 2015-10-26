using System;

namespace SharedModels.Exceptions
{
    internal class InvalidEventRegistrationException : Exception
    {
        public InvalidEventRegistrationException(string message) : base(message)
        {
        }
    }
}