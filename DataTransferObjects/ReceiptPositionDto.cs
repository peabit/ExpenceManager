namespace DataTransferObjects;

public record ReceiptPositionDto(
    int Id, 
    string ProductName, 
    string ProductCategoryName,
    double Price,
    int Quantity, 
    string UnitOfMeasurementName,
    double Coast
);