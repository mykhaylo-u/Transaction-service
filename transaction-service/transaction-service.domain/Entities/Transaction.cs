using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace transaction_service.domain.Entities
{
    public class Transaction : Entity
    {
        [Key]
        [MaxLength(50)]
        public string Id { get; set; }

        [Column(TypeName = "decimal(9, 2)")]
        public decimal Amount { get; set; }

        [MaxLength(3)]
        public string Currency { get; set; }

        public DateTime Date { get; set; }

        public TransactionStatus Status { get; set; }
    }
}
