using DataTransferObjects;

namespace Services.Interfaces;

public interface IReceiptService
{
    Task<ReceiptDto> Create(NewReceiptDto receipt);
    Task<ReceiptPositionDto> CreatePosition(NewReceiptPositionDto position);
    Task<IReadOnlyCollection<ReceiptDto>> GetAll();
    Task<ReceiptDto> Get(int id);
    Task Update(int id, UpdateReceiptDto receipt);
    Task UpdatePosition(int idReceipt, int idPosition, UpdateReceiptPositionDto position);
    Task Delete(int id);
    Task DeletePosition(int idReceipt, int idPosition);
}