using transaction_service.domain;
using transaction_service.domain.Entities;
using transaction_service.domain.Enums;
using transaction_service.domain.ErrorHandling;
using transaction_service.domain.Interfaces;
using transaction_service.services.Services.CsvFileService;
using transaction_service.services.Services.XmlFileService;

namespace transaction_service.services
{
    public class FileParserFactory : IFileParserFactory
    {
        public IFileReader<Transaction> CreateParser(FileExtension fileExtension)
        {
            switch (fileExtension)
            {
                case FileExtension.Csv:
                    return CreateCsvFileParser();
                case FileExtension.Xml:
                    return CreateXmlFileParser();
                default:
                    throw new FileExtensionException();
            }
        }

        private CsvFileParser CreateCsvFileParser()
        {
            return new CsvFileParser();
        }

        private XmlFileParser CreateXmlFileParser()
        {
            return new XmlFileParser();
        }
    }
}
