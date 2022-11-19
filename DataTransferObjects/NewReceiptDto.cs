namespace DataTransferObjects;

public record NewReceiptDto
{
    public string? ShopName { get; set; }   
    public DateTime DateTime { get; set; }
    public IReadOnlyCollection<NewReceiptPositionDto>? Positions { get; set; }
}