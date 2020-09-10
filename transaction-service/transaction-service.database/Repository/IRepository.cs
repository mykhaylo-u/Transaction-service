using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace transaction_service.database.Repository
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        public Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        public IQueryable<TEntity> GetAll();
        public Task<TEntity> AddAsync(TEntity entity);
        public Task<TEntity> UpdateAsync(TEntity entity);
    }
}