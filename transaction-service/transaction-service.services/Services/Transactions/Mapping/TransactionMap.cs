using AutoMapper;
using transaction_service.domain.Dto.Transactions;
using transaction_service.domain.Entities;

namespace transaction_service.services.Services.Transactions.Mapping
{
    public class TransactionMap : Profile
    {
        public TransactionMap()
        {
            CreateMap<Transaction, TransactionDto>()
                .ForMember(dto => dto.Payment, o => o.MapFrom(ent => $"{ent.Amount} {ent.Currency}"))
                .ForMember(dto => dto.Status, o => o.MapFrom(ent => (TransactionStatusEnumDto)ent.Status));
        }
    }
}
