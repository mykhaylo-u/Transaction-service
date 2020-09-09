using transaction_service.domain.Entities;
using transaction_service.domain.Enums;
using transaction_service.domain.ErrorHandling;
using transaction_service.domain.Interfaces;
using transaction_service.services.Services.CsvFileParsers;
using transaction_service.services.Services.XmlFileParsers;

namespace transaction_service.services
{
    public class FileParserFactory : IFileParserFactory
    {
        public IFileParser<Transaction> CreateParser(FileExtension fileExtension)
        {
            switch (fileExtension)
            {
                case FileExtension.Csv:
                    return CreateCsvFileParser();
                case FileExtension.Xml:
                    return CreateXmlFileParser();
                default:
                    throw new InvalidFileExtensionException();
            }
        }

        private TransactionCsvFileParser CreateCsvFileParser()
        {
            return new TransactionCsvFileParser();
        }

        private TransactionXmlFileParser CreateXmlFileParser()
        {
            return new TransactionXmlFileParser();
        }
    }
}
