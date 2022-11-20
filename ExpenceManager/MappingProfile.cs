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
        CreateMap<ReceiptPosition, ReceiptPositionDto>();
        CreateMap<UpdateReceiptDto, Receipt>();
        CreateMap<UpdateReceiptPositionDto, ReceiptPosition>();

        CreateMap<ProductCategory, ProductCategoryDto>();
        CreateMap<NewProductCategoryDto, ProductCategory>();
        CreateMap<UpdateProductCategoryDto, ProductCategory>();

        CreateMap<UnitOfMeasurement, UnitOfMeasurementDto>();
        CreateMap<NewUnitOfMeasurementDto, UnitOfMeasurement>();
        CreateMap<UpdateUnitOfMeasurementDto, UnitOfMeasurement>();
    }
}