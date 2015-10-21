using System;

namespace SharedModels.Exceptions
{
    /// <summary>
    /// This exception should be thrown when 2 passwords do not match.
    /// </summary>
    internal class PasswordsDontMatchException : Exception
    {
        public override string Message => "Wachtwoorden komen niet overeen.";
    }
}