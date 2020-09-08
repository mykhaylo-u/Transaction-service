using System.Collections;
using transaction_service.domain.Dto;

namespace transaction_service.domain
{
    public abstract class FileParser
    {
        public abstract IEnumerable ParseFile(FileDto file);
    }
}
