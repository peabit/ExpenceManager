namespace DataTransferObjects;

public record ReceiptDto
{
    public int Id { get; set; }
    public string? ShopName { get; set; }
    public DateTime DateTime { get; set; }
    public double TotalAmount { get; set; }
}