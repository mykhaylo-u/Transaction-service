using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using transaction_service.domain.Interfaces;
using transaction_service.web.Models.Dto;

namespace transaction_service.web.Controllers.Api
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionApiController : ControllerBase
    {
        private readonly ITransactionsService _transactionsService;
        private readonly IMapper _mapper;

        public TransactionApiController(ITransactionsService transactionsService, IMapper mapper)
        {
            _transactionsService = transactionsService;
            _mapper = mapper;
        }

        [HttpGet("currency")]
        public async Task<IActionResult> GetTransactionsByCurrencyAsync([FromQuery] string code)
        {
            var transactions = await _transactionsService.GetTransactionsByCurrencyAsync(code);
            return Ok(transactions.Select(transaction => _mapper.Map<TransactionDto>(transaction)));
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetTransactionsByStatusAsync([FromQuery] TransactionStatusEnumDto? status)
        {
            var transactions = await _transactionsService.GetTransactionsByStatusAsync(status.HasValue ? (int?)status : null);
            return Ok(transactions.Select(transaction => _mapper.Map<TransactionDto>(transaction)));
        }

        [HttpGet("dateRange")]
        public async Task<IActionResult> GetTransactionsByDateRangeAsync([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var transactions = await _transactionsService.GetTransactionsByDateRangeAsync(startDate, endDate);
            return Ok(transactions.Select(transaction => _mapper.Map<TransactionDto>(transaction)));
        }
    }
}
