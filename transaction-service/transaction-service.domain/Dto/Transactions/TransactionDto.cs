using System.Text.Json.Serialization;

namespace transaction_service.domain.Dto.Transactions
{
    public class TransactionDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("payment")]
        public string Payment { get; set; }

        [JsonPropertyName("Status")]
        public TransactionStatusEnumDto Status { get; set; }
    }
}
