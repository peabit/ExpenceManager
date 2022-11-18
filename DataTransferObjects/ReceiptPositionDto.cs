namespace DataTransferObjects;

public record ReceiptPositionDto(
    int Id, 
    string ProductName, 
    ProductCategoryDto ProductCategory,
    double Price,
    int Quantity, 
    UnitOfMeasurementDto UnitOfMeasurement,
    double Coast
);