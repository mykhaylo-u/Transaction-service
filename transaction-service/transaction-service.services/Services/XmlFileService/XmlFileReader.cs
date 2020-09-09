using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using transaction_service.domain;
using transaction_service.domain.Dto;
using transaction_service.domain.Entities;
using transaction_service.services.Services.XmlFileService.SchemaDocuments;

namespace transaction_service.services.Services.XmlFileService
{
    public class XmlFileReader<T, U> : IFileReader<T> where T : Entity, new() where U : XmlSchemaDocument<T>
    {
        private readonly string _rootNode;

        protected XmlFileReader(string rootNode)
        {
            _rootNode = rootNode;
        }

        public async IAsyncEnumerable<T> ReadFile(FileDto file)
        {
            using var fileStream = new StreamReader(new MemoryStream(file.Content));
            XmlSerializer serializer = new XmlSerializer(typeof(List<U>),
                !string.IsNullOrEmpty(_rootNode) ? new XmlRootAttribute(_rootNode) : null);

            var documentList = (List<U>)serializer.Deserialize(fileStream);

            foreach (var document in documentList)
            {
                yield return await document.ToEntity();
            }
        }
    }
}
