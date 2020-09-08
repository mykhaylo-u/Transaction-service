using transaction_service.domain.Entities;
using transaction_service.services.Services.CsvFileService.Maps;

namespace transaction_service.services.Services.CsvFileService
{
    public class CsvFileParser : CsvFileReader<Transaction, TransactionMap>
    {
    }
}
