using DataTransferObjects;

namespace Services.Interfaces;

public interface IReceiptService
{
    Task<ReceiptDto> Create(NewReceiptDto receipt);
    Task<ReceiptPositionDto> CreatePosition(int receiptId, NewReceiptPositionDto position);
    Task<IReadOnlyCollection<ReceiptDto>> GetAll();
    Task<IReadOnlyCollection<ReceiptDto>> Get(DateTime from, DateTime to);
    Task<ReceiptDto> Get(int id);
    Task<ReceiptDto> Get(string shopName);
    Task Update(int id, UpdateReceiptDto receipt);
    Task UpdatePosition(int idReceipt, int idPosition, UpdateReceiptPositionDto position);
    Task Delete(int id);
    Task DeletePosition(int idReceipt, int idPosition);
}