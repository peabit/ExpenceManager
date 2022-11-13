namespace DataTransferObjects;

public record UpdateReceiptPositionDto(
    string Name,
    int CategoryId,
    double Price,
    int Quantity,
    int UnitOfMeasurementId
);