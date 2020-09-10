using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using transaction_service.database;
using transaction_service.domain.Entities;
using transaction_service.domain.Interfaces;

namespace transaction_service.services.Services.Transactions
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionDbContext _dbContext;

        public TransactionsService(ITransactionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Transaction>> GetTransactionsByCurrencyAsync(string currencyCode)
        {
            bool isCurrencyExist = !string.IsNullOrEmpty(currencyCode);

            return await _dbContext.Transactions
                .Where(transaction => !isCurrencyExist || transaction.Currency == currencyCode)
                .ToListAsync();
        }
        public async Task<List<Transaction>> GetTransactionsByStatusAsync(int? status)
        {
            bool isStatusExist = status.HasValue;

            var entityStatus = status == null ? TransactionStatus.Approved : (TransactionStatus)status.Value;

            return await _dbContext.Transactions.Where(transaction => !isStatusExist || transaction.Status == entityStatus)
                .ToListAsync();
        }

        public async Task<List<Transaction>> GetTransactionsByDateRangeAsync(DateTime? startDate, DateTime? endDate)
        {
            return await _dbContext.Transactions.Where(transaction =>
                    !startDate.HasValue || transaction.Date >= startDate.Value
                    && (!endDate.HasValue || transaction.Date <= endDate.Value))
                .ToListAsync();
        }

        
    }
}
