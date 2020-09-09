using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using transaction_service.domain.Entities;
using transaction_service.domain.Interfaces;

namespace transaction_service.services.Services.XmlFileParsers
{
    public class TransactionXmlFileParser : IFileParser<Transaction>
    {
        public async IAsyncEnumerable<Transaction> ParseFromFile(MemoryStream memoryStream)
        {
            memoryStream.Position = 0;
            using var fileStream = new StreamReader(memoryStream);
            XmlSerializer serializer = new XmlSerializer(typeof(List<XmlTransactionDocument>), new XmlRootAttribute("Transaction"));

            var documentList = (List<XmlTransactionDocument>)serializer.Deserialize(fileStream);

            foreach (var document in documentList)
            {
                yield return await document.MapToEntity();
            }
        }
    }
}
