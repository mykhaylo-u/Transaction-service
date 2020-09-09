using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using transaction_service.domain.Entities;

namespace transaction_service.domain.Interfaces
{
    public interface ITransactionsService
    {
        Task<List<Transaction>> GetTransactionsByCurrency(string currencyCode);
        Task<List<Transaction>> GetTransactionsByStatus(int? status);
        Task<List<Transaction>> GetTransactionsByDateRange(DateTime? startDate, DateTime? endDate);

    }
}
