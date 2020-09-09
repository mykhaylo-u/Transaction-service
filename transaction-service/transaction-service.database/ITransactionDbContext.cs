using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using transaction_service.domain.Entities;

namespace transaction_service.database
{
    public interface ITransactionDbContext : IDisposable
    {
        Task AddRangeAsync(List<Transaction> transactions);
        DbSet<Transaction> Transactions { get; set; }
        void DatabaseCheckCreate();
    }
}
