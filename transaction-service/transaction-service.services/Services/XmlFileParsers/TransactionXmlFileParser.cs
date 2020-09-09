using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using transaction_service.domain.Entities;
using transaction_service.domain.Interfaces;
using transaction_service.services.Services.XmlFileParsers.ErrorHandling;

namespace transaction_service.services.Services.XmlFileParsers
{
    public class TransactionXmlFileParser : IFileParser<Transaction>
    {
        public async IAsyncEnumerable<Transaction> ParseFromFile(MemoryStream memoryStream)
        {
            memoryStream.Position = 0;
            using var fileStream = new StreamReader(memoryStream);
            XmlSerializer serializer = new XmlSerializer(typeof(List<XmlTransactionDocument>), new XmlRootAttribute("Transactions"));
            List<XmlTransactionDocument> documentList = new List<XmlTransactionDocument>();
            try
            {
                documentList = (List<XmlTransactionDocument>)serializer.Deserialize(fileStream);
            }
            catch (Exception e)
            {
                throw new XmlFileParserExeption(e);
            }

            foreach (var document in documentList)
            {
                yield return await document.MapToEntity();
            }
        }
    }
}
