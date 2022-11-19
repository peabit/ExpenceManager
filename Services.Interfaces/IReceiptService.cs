using DataTransferObjects;

namespace Services.Interfaces;

public interface IReceiptService
{
    Task<ReceiptDto> CreateAsync(NewReceiptDto receipt);
    Task<ReceiptPositionDto> CreatePositionAsync(int receiptId, NewReceiptPositionDto position);
    Task DeleteAsync(int id);
    Task DeletePositionAsync(int idReceipt, int idPosition);
    Task<IReadOnlyCollection<ReceiptDto>> GetAllAsync();
    Task<IReadOnlyCollection<ReceiptDto>> GetAsync(DateTime from, DateTime to);
    Task<ReceiptDto> GetAsync(int id);
    Task<IReadOnlyCollection<ReceiptDto>> GetAsync(string shopName);
    Task<IReadOnlyCollection<ReceiptPositionDto>> GetPositionsAsync(int idReceipt);
    Task UpdateAsync(int id, UpdateReceiptDto receipt);
    Task UpdatePosition(int receiptId, int positionId, UpdateReceiptPositionDto position);
}