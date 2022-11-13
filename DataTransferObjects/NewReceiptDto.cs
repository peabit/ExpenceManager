namespace DataTransferObjects;

public record NewReceiptDto(
    string ShopName, 
    DateTime DateTime, 
    IReadOnlyCollection<NewReceiptPositionDto> Positions
);