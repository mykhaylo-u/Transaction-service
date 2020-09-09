using System;

namespace transaction_service.domain.ErrorHandling
{
    public class FileExtensionException : Exception
    {
        public Exception CausingException { get; }

        public FileExtensionException(Exception causingException)
            : base(causingException?.Message ?? "Incorrect file extension.")
        {
            CausingException = causingException;
        }

        public FileExtensionException() : base("Incorrect file extension.")
        {
        }
    }
}
