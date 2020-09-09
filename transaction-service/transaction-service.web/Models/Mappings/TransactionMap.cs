using AutoMapper;
using transaction_service.domain.Entities;
using transaction_service.web.Models.Dto;

namespace transaction_service.web.Models.Mappings
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
