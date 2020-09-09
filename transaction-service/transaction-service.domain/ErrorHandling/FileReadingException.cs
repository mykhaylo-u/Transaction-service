using System;

namespace transaction_service.domain.ErrorHandling
{
    public class FileReadingException : Exception
    {
        public Exception CausingException { get; }

        public FileReadingException(Exception causingException)
            : base(causingException?.Message ?? "Invalid file. Please, see log for details.")
        {
            CausingException = causingException;
        }
    }
}
