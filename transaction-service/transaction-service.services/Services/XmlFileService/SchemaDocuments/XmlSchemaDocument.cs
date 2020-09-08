using System.Threading.Tasks;
using transaction_service.domain.Entities;

namespace transaction_service.services.Services.XmlFileService.SchemaDocuments
{
    public abstract class XmlSchemaDocument<TEntity> where TEntity : Entity
    {
        public abstract Task<TEntity> ToEntity();
    }
}
