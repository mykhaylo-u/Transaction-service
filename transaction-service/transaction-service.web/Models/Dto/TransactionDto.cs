using System.Text.Json.Serialization;

namespace transaction_service.web.Models.Dto
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
