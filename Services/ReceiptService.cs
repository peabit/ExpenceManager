using AutoMapper;
using Entities;
using DataTransferObjects;
using Repositories.Interfaces;
using Services.Interfaces;
using Services.Exceptions;

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

        if (receipts.Count == 0)
        {
            throw new ReceiptCollectionNotFoundException();
        }

        return _mapper.Map<IReadOnlyCollection<ReceiptDto>>(receipts);
    }

    public async Task<IReadOnlyCollection<ReceiptDto>> GetAsync(DateTime from, DateTime to)
    {
        var utcFrom = from.ToUniversalTime();
        var utcTo = to.ToUniversalTime();

        var receipts = await _repository.Receipt.GetAsync(r => r.DateTime >= utcFrom & r.DateTime <= utcTo);

        if (receipts.Count == 0)
        {
            throw new ReceiptNotFoundByPeriodException(from, to);
        }

        return _mapper.Map<IReadOnlyCollection<ReceiptDto>>(receipts);
    }

    public async Task<IReadOnlyCollection<ReceiptDto>> GetAsync(string shopName)
    {
        var receipts = await _repository.Receipt.GetAsync(r => r.ShopName == shopName);

        if (receipts.Count == 0)
        {
            throw new ReceiptNotFoundByShopNameException(shopName);
        }

        return _mapper.Map<IReadOnlyCollection<ReceiptDto>>(receipts);
    }

    public async Task<IReadOnlyCollection<ReceiptPositionDto>> GetPositionsAsync(int receiptId)
    {
        ThrowIfReceiptNotFound(receiptId);

        var positions = await _repository.ReceiptPosition.GetAsync(p => p.ReceiptId == receiptId);
        return _mapper.Map<IReadOnlyCollection<ReceiptPositionDto>>(positions);
    }

    public async Task<ReceiptDto> CreateAsync(NewReceiptDto receipt)
    {
        if (receipt.Positions.Count == 0)
        {
            throw new ReceiptWithoutPositionsException();
        }

        foreach (var position in receipt.Positions)
        {
            ThrowIfProductCategoryNotFound(position.ProductCategoryId);
            ThrowIfUnitOfMeasurementNotFound(position.UnitOfMeasurementId);
        }

        var receiptEntity = _mapper.Map<Receipt>(receipt);
        await _repository.Receipt.CreateAsync(receiptEntity);
        return _mapper.Map<ReceiptDto>(receiptEntity);
    }

    public async Task<ReceiptPositionDto> CreatePositionAsync(int receiptId, NewReceiptPositionDto position)
    {
        ThrowIfReceiptNotFound(receiptId);
        ThrowIfProductCategoryNotFound(position.ProductCategoryId);
        ThrowIfUnitOfMeasurementNotFound(position.UnitOfMeasurementId);

        var positionEntity = _mapper.Map<ReceiptPosition>(position);
        positionEntity.ReceiptId = receiptId;

        await _repository.ReceiptPosition.CreateAsync(positionEntity);

        return _mapper.Map<ReceiptPositionDto>(positionEntity);
    }

    public async Task UpdateAsync(int id, UpdateReceiptDto receipt)
    {
        ThrowIfReceiptNotFound(id);

        var receiptEntity = _mapper.Map<Receipt>(receipt);
        receiptEntity.Id = id;

        await _repository.Receipt.UpdateAsync(receiptEntity);
    }

    public async Task UpdatePositionAsync(int receiptId, int positionId, UpdateReceiptPositionDto position)
    {
        ThrowIfReceiptNotFound(receiptId);

        if (!_repository.ReceiptPosition.Contains(r => r.ReceiptId == receiptId & r.Id == positionId))
        {
            throw new ReceiptPositionNotFoundException(receiptId, positionId);
        }

        ThrowIfProductCategoryNotFound(position.ProductCategoryId);
        ThrowIfUnitOfMeasurementNotFound(position.UnitOfMeasurementId);

        var positionEntity = _mapper.Map<ReceiptPosition>(position);
        positionEntity.ReceiptId = receiptId;
        positionEntity.Id = positionId;

        await _repository.ReceiptPosition.UpdateAsync(positionEntity);
    }

    public async Task DeleteAsync(int id)
    {
        var receipt = await _repository.Receipt.GetFirstOrDefaulAsync(r => r.Id == id);

        if (receipt is null)
        {
            throw new ReceiptNotFoundException(id);
        }

        await _repository.Receipt.DeleteAsync(receipt);
    }

    public async Task DeletePositionAsync(int receiptId, int positionId)
    {
        ThrowIfReceiptNotFound(receiptId);

        var position = await _repository.ReceiptPosition.GetFirstOrDefaulAsync(r => r.ReceiptId == receiptId & r.Id == positionId);

        if (position is null)
        {
            throw new ReceiptPositionNotFoundException(receiptId, positionId);
        }

        await _repository.ReceiptPosition.DeleteAsync(position);
    }

    private void ThrowIfReceiptNotFound(int id)
    {
        if (!_repository.Receipt.Contains(r => r.Id == id))
        {
            throw new ReceiptNotFoundException(id);
        }
    }

    private void ThrowIfProductCategoryNotFound(int productCategoryId)
    {
        if (!_repository.ProductCategory.Contains(pc => pc.Id == productCategoryId))
        {
            throw new ProductCategoryNotFoundException(productCategoryId);
        }
    }

    private void ThrowIfUnitOfMeasurementNotFound(int unitOfMeasurementId)
    {
        if (!_repository.UnitOfMeasurement.Contains(uom => uom.Id == unitOfMeasurementId))
        {
            throw new UnitOfMeasurementNotFoundException(unitOfMeasurementId);
        }
    }
}