using DataTransferObjects;

namespace Services.Interfaces;

public interface IReportService
{
    Task<ProductCategoryReportDto> GetProductCategoryReport(DateTime from, DateTime to);
    Task<ShopReportDto> GetShopReport(DateTime from, DateTime to);
}