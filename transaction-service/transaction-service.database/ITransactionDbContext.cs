using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using transaction_service.domain.Entities;

namespace transaction_service.database
{
    public interface ITransactionDbContext : IDisposable
    {
        Task<Transaction> Add(Transaction transaction);
        Task<Transaction> AddAsync(Transaction trans);
        DbSet<Transaction> Transactions { get; set; }
        void DatabaseCheckCreate();
    }
}
