using System.Collections.Generic;
using transaction_service.domain.Dto;
using transaction_service.domain.Entities;

namespace transaction_service.domain
{
    public interface IFileReader<T> where T : Entity
    {
        public IAsyncEnumerable<T> ReadFile(FileDto file);
    }
}
