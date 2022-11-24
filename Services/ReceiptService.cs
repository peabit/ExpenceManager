using AutoMapper;
using Services.Interfaces;
using Entities;
using DataTransferObjects;
using Repositories.Interfaces;

namespace Services;

public sealed class ReceiptService : IReceiptService
{
    private readonly IRepository<Receipt> _receiptRepository;
    private readonly IRepository<ReceiptPosition> _positionRepository;
    private readonly IMapper _mapper;

    public ReceiptService(IRepository<Receipt> receiptRepository, IRepository<ReceiptPosition> positionRepository, IMapper mapper)
    {
        _receiptRepository = receiptRepository;
        _positionRepository = positionRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<ReceiptDto>> GetAllAsync()
    {
        var receipts = await _receiptRepository.GetAllAsync();
        return _mapper.Map<IReadOnlyCollection<ReceiptDto>>(receipts);
    }

    public async Task<IReadOnlyCollection<ReceiptDto>> GetAsync(DateTime from, DateTime to)
    {
        var utcFrom = from.ToUniversalTime();
        var utcTo = to.ToUniversalTime();

        var receipts = await _receiptRepository.GetAsync(r => r.DateTime >= utcFrom & r.DateTime <= utcTo);

        return _mapper.Map<IReadOnlyCollection<ReceiptDto>>(receipts);
    }

    public async Task<IReadOnlyCollection<ReceiptDto>> GetAsync(string shopName)
    {
        var receipts = await _receiptRepository.GetAsync(r => r.ShopName == shopName);
        return _mapper.Map<IReadOnlyCollection<ReceiptDto>>(receipts);
    }

    public async Task<IReadOnlyCollection<ReceiptPositionDto>> GetPositionsAsync(int receiptId)
    {
        var positions = await _positionRepository.GetAsync(p => p.ReceiptId == receiptId);
        return _mapper.Map<IReadOnlyCollection<ReceiptPositionDto>>(positions);
    }

    public async Task<ReceiptDto> CreateAsync(NewReceiptDto receipt)
    {
        var receiptEntity = _mapper.Map<Receipt>(receipt);
        await _receiptRepository.CreateAsync(receiptEntity);
        return _mapper.Map<ReceiptDto>(receiptEntity);
    }

    public async Task<ReceiptPositionDto> CreatePositionAsync(int id, NewReceiptPositionDto position)
    {
        var positionEntity = _mapper.Map<ReceiptPosition>(position);
        positionEntity.ReceiptId = id;

        await _positionRepository.CreateAsync(positionEntity);

        return _mapper.Map<ReceiptPositionDto>(positionEntity);
    }

    public async Task UpdateAsync(int id, UpdateReceiptDto receipt)
    {
        var receiptEntity = _mapper.Map<Receipt>(receipt);
        receiptEntity.Id = id;

        await _receiptRepository.UpdateAsync(receiptEntity);
    }

    public async Task UpdatePositionAsync(int receiptId, int positionId, UpdateReceiptPositionDto position)
    {
        var positionEntity = _mapper.Map<ReceiptPosition>(position);
        positionEntity.ReceiptId = receiptId;
        positionEntity.Id = positionId;

        await _positionRepository.UpdateAsync(positionEntity);
    }

    public async Task DeleteAsync(int id)
    {
        var receipt = await _receiptRepository.GetFirstAsync(r => r.Id == id);
        await _receiptRepository.DeleteAsync(receipt);
    }

    public async Task DeletePositionAsync(int receiptId, int positionId)
    {
        var position = await _positionRepository.GetFirstAsync(r => r.ReceiptId == receiptId & r.Id == positionId);
        await _positionRepository.DeleteAsync(position);
    }
}