using Entities;
using Services.Interfaces;
using DataTransferObjects;
using Repositories.Interfaces;

namespace Services;

public class ReceiptService : ServiceBase<Receipt>, IReceiptService
{
    public ReceiptService(IRepository<Receipt> repository) : base(repository) { }

    public Task<ReceiptDto> Create(NewReceiptDto receipt)
    {
        throw new NotImplementedException();
    }

    public Task<ReceiptPositionDto> CreatePosition(int receiptId, NewReceiptPositionDto position)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task DeletePosition(int idReceipt, int idPosition)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<ReceiptDto>> Get(DateTime from, DateTime to)
    {
        throw new NotImplementedException();
    }

    public Task<ReceiptDto> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ReceiptDto> Get(string shopName)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<ReceiptDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, UpdateReceiptDto receipt)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePosition(int idReceipt, int idPosition, UpdateReceiptPositionDto position)
    {
        throw new NotImplementedException();
    }
}