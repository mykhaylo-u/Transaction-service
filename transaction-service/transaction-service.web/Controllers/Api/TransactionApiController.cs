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
        public async Task<IActionResult> GetTransactionsByCurrency([FromQuery] string code)
        {
            var transactions = await _transactionsService.GetTransactionsByCurrency(code);
            return Ok(transactions.Select(transaction => _mapper.Map<TransactionDto>(transaction)));
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetTransactionsByStatus([FromQuery] TransactionStatusEnumDto? status)
        {
            var transactions = await _transactionsService.GetTransactionsByStatus(status.HasValue ? (int?)status : null);
            return Ok(transactions.Select(transaction => _mapper.Map<TransactionDto>(transaction)));
        }

        [HttpGet("dateRange")]
        public async Task<IActionResult> GetTransactionsByDateRange([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var transactions = await _transactionsService.GetTransactionsByDateRange(startDate, endDate);
            return Ok(transactions.Select(transaction => _mapper.Map<TransactionDto>(transaction)));
        }
    }
}
