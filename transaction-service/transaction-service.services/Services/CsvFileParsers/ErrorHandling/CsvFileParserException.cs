using System;

namespace transaction_service.services.Services.CsvFileService.ErrorHandling
{
    public class CsvFileParserException : Exception
    {
        public int InvalidRow { get; set; }
        public CsvFileParserException(int invalidRow) : base($"incorrect symbol at raw and position: {invalidRow}")
        {
        }
    }
}
