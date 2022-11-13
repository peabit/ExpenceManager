namespace DataTransferObjects;

public record ReceiptPositionDto(
    int Id, 
    string Name, 
    ProductCategoryDto Category,
    double Price,
    int Quantity, 
    UnitOfMeasurementDto UnitOfMeasurement,
    double Coast
);