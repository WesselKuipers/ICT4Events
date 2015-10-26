using System;

namespace ICT4Events.Views.Reservation_System.Forms
{
    internal class InvalidEventRegistrationException : Exception
    {
        public InvalidEventRegistrationException(string message) : base(message)
        {
        }
    }
}