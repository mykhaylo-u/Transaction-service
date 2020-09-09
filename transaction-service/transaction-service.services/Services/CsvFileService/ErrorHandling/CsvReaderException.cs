using System;

namespace transaction_service.services.Services.CsvFileService.ErrorHandling
{
    public class CsvReaderException : Exception
    {
        public CsvReaderException(string errorMsg) : base(errorMsg)
        {
        }
    }
}
