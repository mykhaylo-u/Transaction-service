using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using transaction_service.domain.Entities;

namespace transaction_service.domain.Interfaces
{
    public interface ITransactionsService
    {
        Task<List<Transaction>> GetTransactionsByCurrencyAsync(string currencyCode);
        Task<List<Transaction>> GetTransactionsByStatusAsync(int? status);
        Task<List<Transaction>> GetTransactionsByDateRangeAsync(DateTime? startDate, DateTime? endDate);

    }
}
