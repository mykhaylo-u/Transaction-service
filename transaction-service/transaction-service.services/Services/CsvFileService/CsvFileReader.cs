using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using transaction_service.domain;
using transaction_service.domain.Dto;
using transaction_service.domain.Entities;
using transaction_service.services.Services.CsvFileService.ErrorHandling;

namespace transaction_service.services.Services.CsvFileService
{
    public class CsvFileReader<T, U> : IFileReader<T> where T : Entity, new() where U : ClassMap<T>
    {
        public async IAsyncEnumerable<T> ReadFile(FileDto file)
        {
            using var reader = new StreamReader(new MemoryStream(file.Content));
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Configuration.BadDataFound = context =>
                throw new CsvReaderException($"incorrect symbol at raw and position: {context.RawRecordEndPosition}");
            csv.Configuration.HasHeaderRecord = false;
            csv.Configuration.RegisterClassMap<U>();

            await foreach (var record in csv.GetRecordsAsync<T>())
            {
                yield return record;
            }
        }
    }
}
