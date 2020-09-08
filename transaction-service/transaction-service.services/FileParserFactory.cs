using System;
using transaction_service.domain;
using transaction_service.domain.Enums;
using transaction_service.domain.Interfaces;
using transaction_service.services.Services.CsvFileParser;
using transaction_service.services.Services.XmlFileParser;

namespace transaction_service.services
{
    public class FileParserFactory : IFileParserFactory
    {
        public IFileParser CreateParser(FileExtension fileExtension)
        {
            switch (fileExtension)
            {
                case FileExtension.Csv:
                    return CreateCsvFileReader();
                case FileExtension.Xml:
                    return CreateXmlFileReader();
                default:
                    //TODO: Error proper error handling
                    throw new NotImplementedException();
            }
        }

        private CsvFileReader CreateCsvFileReader()
        {
            return new CsvFileReader();
        }

        private XmlFileReader CreateXmlFileReader()
        {
            return new XmlFileReader();
        }
    }
}
