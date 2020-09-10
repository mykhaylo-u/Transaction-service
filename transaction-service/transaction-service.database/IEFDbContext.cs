using Microsoft.EntityFrameworkCore;
using transaction_service.domain.Entities;

namespace transaction_service.database
{
    public interface IEFDbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
    }
}