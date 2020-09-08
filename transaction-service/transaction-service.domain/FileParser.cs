using System.Collections;
using transaction_service.domain.Dto;

namespace transaction_service.domain
{
    public interface IFileParser
    {
        public IEnumerable ParseFile(FileDto file);
    }
}
