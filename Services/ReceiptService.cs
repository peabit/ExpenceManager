using AutoMapper;
using Services.Interfaces;
using Entities;
using DataTransferObjects;
using Repositories.Interfaces;
using Repositories;

namespace Services;

public sealed class ReceiptService : IReceiptService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public ReceiptService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repository = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<ReceiptDto>> GetAllAsync()
    {
        var receipts = await _repository.Receipt.GetAllAsync();
        return _mapper.Map<IReadOnlyCollection<ReceiptDto>>(receipts);
    }

    public async Task<IReadOnlyCollection<ReceiptDto>> GetAsync(DateTime from, DateTime to)
    {
        var utcFrom = from.ToUniversalTime();
        var utcTo = to.ToUniversalTime();

        var receipts = await _repository.Receipt.GetAsync(r => r.DateTime >= utcFrom & r.DateTime <= utcTo);

        return _mapper.Map<IReadOnlyCollection<ReceiptDto>>(receipts);
    }

    public async Task<IReadOnlyCollection<ReceiptDto>> GetAsync(string shopName)
    {
        var receipts = await _repository.Receipt.GetAsync(r => r.ShopName == shopName);
        return _mapper.Map<IReadOnlyCollection<ReceiptDto>>(receipts);
    }

    public async Task<IReadOnlyCollection<ReceiptPositionDto>> GetPositionsAsync(int receiptId)
    {
        var positions = await _repository.ReceiptPosition.GetAsync(p => p.ReceiptId == receiptId);
        return _mapper.Map<IReadOnlyCollection<ReceiptPositionDto>>(positions);
    }

    public async Task<ReceiptDto> CreateAsync(NewReceiptDto receipt)
    {
        var receiptEntity = _mapper.Map<Receipt>(receipt);
        await _repository.Receipt.CreateAsync(receiptEntity);
        return _mapper.Map<ReceiptDto>(receiptEntity);
    }

    public async Task<ReceiptPositionDto> CreatePositionAsync(int id, NewReceiptPositionDto position)
    {
        var positionEntity = _mapper.Map<ReceiptPosition>(position);
        positionEntity.ReceiptId = id;

        await _repository.ReceiptPosition.CreateAsync(positionEntity);

        return _mapper.Map<ReceiptPositionDto>(positionEntity);
    }

    public async Task UpdateAsync(int id, UpdateReceiptDto receipt)
    {
        var receiptEntity = _mapper.Map<Receipt>(receipt);
        receiptEntity.Id = id;

        await _repository.Receipt.UpdateAsync(receiptEntity);
    }

    public async Task UpdatePositionAsync(int receiptId, int positionId, UpdateReceiptPositionDto position)
    {
        var positionEntity = _mapper.Map<ReceiptPosition>(position);
        positionEntity.ReceiptId = receiptId;
        positionEntity.Id = positionId;

        await _repository.ReceiptPosition.UpdateAsync(positionEntity);
    }

    public async Task DeleteAsync(int id)
    {
        var receipt = await _repository.Receipt.GetFirstAsync(r => r.Id == id);
        await _repository.Receipt.DeleteAsync(receipt);
    }

    public async Task DeletePositionAsync(int receiptId, int positionId)
    {
        var position = await _repository.ReceiptPosition.GetFirstAsync(r => r.ReceiptId == receiptId & r.Id == positionId);
        await _repository.ReceiptPosition.DeleteAsync(position);
    }
}