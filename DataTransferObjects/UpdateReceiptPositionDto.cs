namespace DataTransferObjects;

public record UpdateReceiptPositionDto(
    string ProductName,
    int ProductCategoryId,
    double Price,
    int Quantity,
    int UnitOfMeasurementId
);