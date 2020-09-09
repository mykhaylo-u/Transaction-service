using transaction_service.domain.Entities;
using transaction_service.domain.Enums;


namespace transaction_service.domain.Interfaces
{
    public interface IFileParserFactory
    {
        IFileParser<Transaction> CreateParser(FileExtension fileExtension);
    }
}
