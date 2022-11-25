using AutoMapper;
using Entities;
using Entities.Exceptions;
using DataTransferObjects;
using Repositories.Interfaces;
using Services.Interfaces;

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

        ThrowIfReceiptsNotFound(receipts);

        return _mapper.Map<IReadOnlyCollection<ReceiptDto>>(receipts);
    }

    public async Task<IReadOnlyCollection<ReceiptDto>> GetAsync(string shopName)
    {
        var receipts = await _repository.Receipt.GetAsync(r => r.ShopName == shopName);

        ThrowIfReceiptsNotFound(receipts);

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

    public async Task<ReceiptPositionDto> CreatePositionAsync(int receiptId, NewReceiptPositionDto position)
    {
        ThrowIfReceiptNotExist(receiptId);

        var positionEntity = _mapper.Map<ReceiptPosition>(position);
        positionEntity.ReceiptId = receiptId;

        await _repository.ReceiptPosition.CreateAsync(positionEntity);

        return _mapper.Map<ReceiptPositionDto>(positionEntity);
    }

    public async Task UpdateAsync(int id, UpdateReceiptDto receipt)
    {
        ThrowIfReceiptNotExist(id);

        var receiptEntity = _mapper.Map<Receipt>(receipt);
        receiptEntity.Id = id;

        await _repository.Receipt.UpdateAsync(receiptEntity);
    }

    public async Task UpdatePositionAsync(int receiptId, int positionId, UpdateReceiptPositionDto position)
    {
        ThrowIfReceiptNotExist(receiptId);

        if (!_repository.ReceiptPosition.Contains(r => r.Id == positionId))
        {
            // TODO
        }

        if (!_repository.ProductCategory.Contains(p => p.Id == position.ProductCategoryId))
        {
            throw new ProductCategoryNotFoundException(position.ProductCategoryId);
        }

        if (!_repository.UnitOfMeasurement.Contains(u => u.Id == position.UnitOfMeasurementId))
        {
            throw new UnitOfMeasurementNotFoundException(position.UnitOfMeasurementId);
        }

        var positionEntity = _mapper.Map<ReceiptPosition>(position);
        positionEntity.ReceiptId = receiptId;
        positionEntity.Id = positionId;

        await _repository.ReceiptPosition.UpdateAsync(positionEntity);
    }

    public async Task DeleteAsync(int id)
    {
        var receipt = await _repository.Receipt.GetFirstAsync(r => r.Id == id);

        if (receipt is null)
        {
            // TODO
        }

        await _repository.Receipt.DeleteAsync(receipt);
    }

    public async Task DeletePositionAsync(int receiptId, int positionId)
    {
        ThrowIfReceiptNotExist(receiptId);

        var position = await _repository.ReceiptPosition.GetFirstAsync(r => r.ReceiptId == receiptId & r.Id == positionId);

        if (position is null)
        {
            // TODO
        }

        await _repository.ReceiptPosition.DeleteAsync(position);
    }

    private void ThrowIfReceiptNotExist(int id)
    {
        if (!_repository.Receipt.Contains(r => r.Id == id))
        {
            // TODO
        }
    }

    private void ThrowIfReceiptsNotFound(IReadOnlyCollection<Receipt> receipts)
    {
        if (receipts.Count == 0)
        {
            // TODO 
        }
    }
}