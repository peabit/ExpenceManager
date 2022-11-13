using DataTransferObjects;

namespace Services.Interfaces;

internal interface IReportService
{
    Task GetProductCategoriesReport(DateTime from, DateTime to);
    Task GetShopsReport(DateTime from, DateTime to);
}