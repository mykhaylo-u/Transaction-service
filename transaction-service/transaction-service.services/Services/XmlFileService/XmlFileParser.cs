using transaction_service.domain.Entities;
using transaction_service.services.Services.XmlFileService.SchemaDocuments;

namespace transaction_service.services.Services.XmlFileService
{
    public class XmlFileParser : XmlFileReader<Transaction, XmlTransactionDocument>
    {
        public XmlFileParser() : base("Transactions")
        {
        }
    }
}
