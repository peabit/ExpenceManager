using DataTransferObjects;

namespace Services.Interfaces;

public interface IReceiptService
{
    Task<ReceiptDto> CreateAsync(NewReceiptDto receipt);
    Task<ReceiptPositionDto> CreatePositionAsync(int receiptId, NewReceiptPositionDto position);
    Task DeleteAsync(int receiptId);
    Task DeletePositionAsync(int receiptId, int positionId);
    Task<IReadOnlyCollection<ReceiptDto>> GetAllAsync();
    Task<IReadOnlyCollection<ReceiptDto>> GetAsync(DateTime from, DateTime to);
    Task<IReadOnlyCollection<ReceiptDto>> GetAsync(string shopName);
    Task<IReadOnlyCollection<ReceiptPositionDto>> GetPositionsAsync(int receiptId);
    Task UpdateAsync(int receiptId, UpdateReceiptDto receipt);
    Task UpdatePositionAsync(int receiptId, int positionId, UpdateReceiptPositionDto position);
}