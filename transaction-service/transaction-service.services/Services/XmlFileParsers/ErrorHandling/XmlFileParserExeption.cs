using System;

namespace transaction_service.services.Services.XmlFileParsers.ErrorHandling
{
    public class XmlFileParserExeption : Exception
    {
        public Exception CausingException { get; }

        public XmlFileParserExeption(Exception causingException)
            : base($"Xml parsing process failed: {causingException?.Message}")
        {
            CausingException = causingException;
        }

        public XmlFileParserExeption() : base($"Xml parsing process failed")
        {
        }
    }
}
