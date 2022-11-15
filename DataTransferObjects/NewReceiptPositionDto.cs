namespace DataTransferObjects;

public record NewReceiptPositionDto(
    string ProductName, 
    int ProductCategoryId,
    double Price,
    int Quantity,
    int UnitOfMeasurementId
);