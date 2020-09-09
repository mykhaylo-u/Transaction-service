using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using transaction_service.domain.Entities;

namespace transaction_service.database
{
    public class TransactionDbContext : DbContext, ITransactionDbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public void DatabaseCheckCreate()
        {
            try
            {
                Database.Migrate();
            }
            catch
            {
            }
        }

        public async Task AddRangeAsync(List<Transaction> transactions)
        {
            await base.AddRangeAsync(transactions);
            await base.SaveChangesAsync();
        }

    }
}
