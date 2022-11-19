﻿using AutoMapper;
using Services.Interfaces;
using Entities;
using DataTransferObjects;
using Repositories.Interfaces;

namespace Services;

public sealed class ReceiptService : IReceiptService
{
    private readonly IReceiptRepository _repository;
    private readonly IMapper _mapper;

    public ReceiptService(IReceiptRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ReceiptDto> CreateAsync(NewReceiptDto receipt)
    {
        var receiptEntity = _mapper.Map<Receipt>(receipt);
        await _repository.CreateAsync(receiptEntity);
        return _mapper.Map<ReceiptDto>(receiptEntity);
    }

    public async Task<ReceiptPositionDto> CreatePositionAsync(int receiptId, NewReceiptPositionDto position)
    {
        ThrowIfReceiptNotExist(receiptId);

        var positionEntity = _mapper.Map<ReceiptPosition>(position);
        positionEntity.ReceiptId = receiptId;

        // TODO: Add filling navigation properties
        await _repository.CreatePositionAsync(positionEntity);

        return _mapper.Map<ReceiptPositionDto>(positionEntity);
    }

    public async Task DeleteAsync(int id)
    {
        ThrowIfReceiptNotExist(id);
        await _repository.DeleteAsync(id);
    }

    public async Task DeletePositionAsync(int idReceipt, int idPosition)
    {
        ThrowIfReceiptNotExist(idReceipt);
        ThrowIfPositionNotExist(idReceipt, idPosition);

        await _repository.DeletePositionAsync(idReceipt, idPosition);
    }

    public async Task<IReadOnlyCollection<ReceiptDto>> GetAllAsync()
    {
        var receipts = await _repository.GetAllAsync();

        if (receipts is null)
        {
            // TODO: Exception
        }

        return _mapper.Map<IReadOnlyCollection<ReceiptDto>>(receipts);
    }

    public async Task<IReadOnlyCollection<ReceiptDto>> GetAsync(DateTime from, DateTime to)
    {
        var receipts = await _repository.GetAsync(r => r.DateTime >= from & r.DateTime <= to);

        if (receipts is null)
        {
            // TODO: Exception
        }

        return _mapper.Map<IReadOnlyCollection<ReceiptDto>>(receipts);
    }

    public async Task<ReceiptDto> GetAsync(int id)
    {
        var receipt = await _repository.GetAsync(id);

        if (receipt is null)
        {
            // TODO: Exceiption
        }

        return _mapper.Map<ReceiptDto>(receipt);
    }

    public async Task<IReadOnlyCollection<ReceiptDto>> GetAsync(string shopName)
    {
        var receipts = await _repository.GetAsync(r => r.ShopName == shopName);

        if (receipts is null)
        {
            // TODO: Exception
        }

        return _mapper.Map<IReadOnlyCollection<ReceiptDto>>(receipts);
    }

    public async Task<IReadOnlyCollection<ReceiptPositionDto>> GetPositionsAsync(int idReceipt)
    {
        var positions = await _repository.GetPositionsAsync(idReceipt);

        if (positions is null)
        {
            // TODO: Exception
        }

        return _mapper.Map<IReadOnlyCollection<ReceiptPositionDto>>(positions);
    }

    public async Task UpdateAsync(int id, UpdateReceiptDto receipt)
    {
        var receiptEntity = _mapper.Map<Receipt>(receipt);
        receiptEntity.Id = id;

        await _repository.UpdateAsync(receiptEntity);
    }

    public async Task UpdatePosition(int receiptId, int positionId, UpdateReceiptPositionDto position)
    {
        var positionEntity = _mapper.Map<ReceiptPosition>(position);
        positionEntity.ReceiptId = receiptId;
        positionEntity.Id = positionId;

        await _repository.UpdatePositionAsync(positionEntity);
    }

    private void ThrowIfReceiptNotExist(int id)
    {

    }

    private void ThrowIfPositionNotExist(int idReceipt, int idPosition)
    {

    }
}   