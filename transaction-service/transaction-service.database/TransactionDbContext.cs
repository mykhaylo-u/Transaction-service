using Microsoft.EntityFrameworkCore;
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

        public async Task<Transaction> Add(Transaction transaction)
        {
            var createdEntry = Transactions.Attach(transaction);
            base.Entry(transaction).State = EntityState.Added;
            return createdEntry.Entity;
        }

        public async Task<Transaction> AddAsync(Transaction trans)
        {
            await base.AddAsync(trans);
            return trans;
        }

        public override async ValueTask DisposeAsync()
        {
            await SaveChangesAsync();
            await base.DisposeAsync();
        }
    }
}
