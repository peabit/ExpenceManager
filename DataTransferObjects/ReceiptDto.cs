namespace DataTransferObjects;

public record ReceiptDto(
    int Id,
    string ShopName,
    DateTime DateTime, 
    double TotalAmount, 
    IReadOnlyCollection<ReceiptPositionDto> Positions
);