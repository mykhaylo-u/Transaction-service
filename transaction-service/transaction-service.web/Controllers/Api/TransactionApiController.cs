using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using transaction_service.domain.Dto.Transactions;
using transaction_service.domain.Interfaces;

namespace transaction_service.web.Controllers.Api
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionApiController : ControllerBase
    {
        private readonly ITransactionsService _transactionsService;

        public TransactionApiController(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        [HttpGet("currency")]
        public async Task<IActionResult> GetTransactionsByCurrencyAsync([FromQuery] string code)
        {
            var transactions = await _transactionsService.GetTransactionsByCurrencyAsync(code);
            return Ok(transactions);
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetTransactionsByStatusAsync([FromQuery] TransactionStatusEnumDto? status)
        {
            var transactions = await _transactionsService.GetTransactionsByStatusAsync(status.HasValue ? (int?)status : null);
            return Ok(transactions);
        }

        [HttpGet("dateRange")]
        public async Task<IActionResult> GetTransactionsByDateRangeAsync([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var transactions = await _transactionsService.GetTransactionsByDateRangeAsync(startDate, endDate);
            return Ok(transactions);
        }
    }
}
