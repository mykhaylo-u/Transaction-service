using transaction_service.domain.Enums;


namespace transaction_service.domain.Interfaces
{
    public interface IFileParserFactory
    {
        IFileParser CreateParser(FileExtension fileExtension);
    }
}
