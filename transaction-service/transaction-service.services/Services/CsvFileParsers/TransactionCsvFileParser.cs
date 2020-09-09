using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using transaction_service.domain.Entities;
using transaction_service.domain.Interfaces;
using transaction_service.services.Services.CsvFileService.ErrorHandling;

namespace transaction_service.services.Services.CsvFileParsers
{
    public class TransactionCsvFileParser : IFileParser<Transaction>
    {
        public async IAsyncEnumerable<Transaction> ParseFromFile(MemoryStream memoryStream)
        {
            memoryStream.Position = 0;
            using var reader = new StreamReader(memoryStream);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Configuration.BadDataFound = context => throw new CsvFileParserException(context.RawRecordEndPosition);
            csv.Configuration.HasHeaderRecord = false;
            csv.Configuration.RegisterClassMap<TransactionMap>();

            await foreach (var record in csv.GetRecordsAsync<Transaction>())
            {
                yield return record;
            }
        }
    }
}
