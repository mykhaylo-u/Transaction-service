using System.Collections.Generic;
using System.IO;

namespace transaction_service.domain.Interfaces
{
    public interface IFileParser<T> where T : class
    {
        public IAsyncEnumerable<T> ParseFromFile(MemoryStream memoryStream);
    }
}
