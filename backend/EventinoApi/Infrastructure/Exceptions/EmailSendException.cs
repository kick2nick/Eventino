using System;

namespace Infrastructure.Exceptions
{
    public class EmailSendException : Exception
    {
        public EmailSendException()
        {

        }

        public EmailSendException(string message) : base(message)
        {

        }

        public EmailSendException(Exception ex, string message) : base(message, ex)
        {

        }
    }
}
