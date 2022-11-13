namespace DataTransferObjects;

public record NewReceiptPositionDto(
    string Name, 
    int CategoryId,
    double Price,
    int Quantity,
    int UnitOfMeasurementId
);