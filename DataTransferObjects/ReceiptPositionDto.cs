namespace DataTransferObjects;

public record ReceiptPositionDto(
    int Id, 
    string ProductName, 
    string ProductCategory,
    double Price,
    int Quantity, 
    string UnitOfMeasurement,
    double Coast
);