using CsvHelper.Configuration;
using System;
using transaction_service.domain.Entities;

namespace transaction_service.services.Services.CsvFileService.Maps
{
    public class TransactionMap : ClassMap<Transaction>
    {
        public TransactionMap()
        {
            Map(m => m.Id).Index(0);
            Map(m => m.Amount).Index(1);
            Map(m => m.Currency).Index(2);
            Map(m => m.Date).ConvertUsing(row =>
            {
                var field = row.GetField(3);
                return DateTime.ParseExact(field, "dd/MM/yyyy HH:mm:ss", null);
            });
            Map(m => m.Status).Index(4);
        }
    }
}
