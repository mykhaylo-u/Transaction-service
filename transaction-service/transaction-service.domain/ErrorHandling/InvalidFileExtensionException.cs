using System;

namespace transaction_service.domain.ErrorHandling
{
    public class InvalidFileExtensionException : Exception
    {
        public Exception CausingException { get; }

        public InvalidFileExtensionException(Exception causingException)
            : base(causingException?.Message ?? "Incorrect file extension.")
        {
            CausingException = causingException;
        }

        public InvalidFileExtensionException() : base("Incorrect file extension.")
        {
        }
    }
}
