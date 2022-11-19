using AutoMapper;
using Entities;
using DataTransferObjects;

namespace ExpenceManager;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Receipt, ReceiptDto>();
        CreateMap<NewReceiptDto, Receipt>();
        CreateMap<NewReceiptPositionDto, ReceiptPosition>();

        CreateMap<ReceiptPosition, ReceiptPositionDto>()
            .ForMember(
                dto => dto.ProductCategory, opt => opt.MapFrom(p => p.ProductCategory.Name)
            )
            .ForMember(
                dto => dto.UnitOfMeasurement, opt => opt.MapFrom(p => p.UnitOfMeasurement.Name)
            );
    }
}