namespace DataTransferObjects;

public record NewReceiptPositionDto
{
    public string? ProductName { get; set; }
    public int ProductCategoryId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public int UnitOfMeasurementId { get; set; }
};