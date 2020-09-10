using Microsoft.EntityFrameworkCore;
using transaction_service.domain.Entities;

namespace transaction_service.database
{
    public class EFDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
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
    }
}
