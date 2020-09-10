using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using transaction_service.domain.Dto.Transactions;
using transaction_service.domain.Entities;

namespace transaction_service.domain.Interfaces
{
    public interface ITransactionsService
    {
        public Task AddTransactionRangeAsync(List<Transaction> transactions);
        public Task<List<TransactionDto>> GetTransactionsByCurrencyAsync(string currencyCode);
        public Task<List<TransactionDto>> GetTransactionsByStatusAsync(int? status);
        public Task<List<TransactionDto>> GetTransactionsByDateRangeAsync(DateTime? startDate, DateTime? endDate);

    }
}
