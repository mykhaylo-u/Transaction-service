using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using transaction_service.database.Repository;
using transaction_service.domain.Dto.Transactions;
using transaction_service.domain.Entities;
using transaction_service.domain.Interfaces;

namespace transaction_service.services.Services.Transactions
{
    public class TransactionsService : ITransactionsService
    {
        private readonly IRepository<Transaction> _repository;
        private readonly IMapper _mapper;

        public TransactionsService(IRepository<Transaction> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddTransactionRangeAsync(List<Transaction> transactions)
        {
            await _repository.AddRangeAsync(transactions);
        }

        public async Task<List<TransactionDto>> GetTransactionsByCurrencyAsync(string currencyCode)
        {
            bool isCurrencyExist = !string.IsNullOrEmpty(currencyCode);

            return await _repository.GetAll().Where(transaction => !isCurrencyExist || transaction.Currency == currencyCode)
                .Select(transaction => _mapper.Map<TransactionDto>(transaction)).ToListAsync();
        }
        public async Task<List<TransactionDto>> GetTransactionsByStatusAsync(int? status)
        {
            bool isStatusExist = status.HasValue;

            var entityStatus = status == null ? TransactionStatus.Approved : (TransactionStatus)status.Value;
            return await _repository.GetAll().Where(transaction => !isStatusExist || transaction.Status == entityStatus)
                .Select(transaction => _mapper.Map<TransactionDto>(transaction)).ToListAsync();
        }

        public async Task<List<TransactionDto>> GetTransactionsByDateRangeAsync(DateTime? startDate, DateTime? endDate)
        {
            return await _repository.GetAll().Where(transaction =>
                    !startDate.HasValue || transaction.Date >= startDate.Value
                    && (!endDate.HasValue || transaction.Date <= endDate.Value))
                .Select(transaction => _mapper.Map<TransactionDto>(transaction)).ToListAsync();
        }


    }
}
