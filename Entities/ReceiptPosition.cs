namespace Entities;

public class ReceiptPosition : Entity
{
    public int ReceiptId { get; set; }
    public string? ProductName { get; set; }
    public string? ProductCategory { get; set; }
    public double? Price { get; set; }
    public int Quantity { get; set; }
    public string? UnitOfMeasurement { get; set; }
    public double Coast { get; set; }
}