using DataTransferObjects;

namespace Services.Interfaces;

internal interface IReportService
{
    Task<ProductCategoryReportDto> GetProductCategoryReport(DateTime from, DateTime to);
    Task<ShopReportDto> GetShopReport(DateTime from, DateTime to);
}