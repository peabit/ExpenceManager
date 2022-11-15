namespace Entities;

public class ReceiptPosition : Entity
{
    public int ReceiptId { get; set; }
    public string? ProductName { get; set; }
    public int? ProductCategoryId { get; set; }
    public ProductCategory? ProductCategory { get; set; } 
    public double? Price { get; set; }
    public int Quantity { get; set; }
    public int? UnitOfMeasurementId { get; set; }
    public UnitOfMeasurement? UnitOfMeasurement { get; set; } 
    public double Coast { get; set; }
}