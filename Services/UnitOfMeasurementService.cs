using AutoMapper;
using Services.Interfaces;
using Entities;
using Repositories.Interfaces;
using DataTransferObjects;

namespace Services;

public sealed class UnitOfMeasurementService : IUnitOfMeasurementService
{
    private readonly IRepository<UnitOfMeasurement> _unitOfMeasurementRepository;
    private readonly IMapper _mapper;

    public UnitOfMeasurementService(IRepository<UnitOfMeasurement> unitOfMeasurementRepository, IMapper mapper)
    {
        _unitOfMeasurementRepository = unitOfMeasurementRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<UnitOfMeasurementDto>> GetAllAsync()
    {
        var unitsOfMeasurement = await _unitOfMeasurementRepository.GetAllAsync();
        return _mapper.Map<IReadOnlyCollection<UnitOfMeasurementDto>>(unitsOfMeasurement);
    }

    public async Task<UnitOfMeasurementDto> CreateAsync(NewUnitOfMeasurementDto unitOfMeasurement)
	{
        var unitOfMeasurementEntity = _mapper.Map<UnitOfMeasurement>(unitOfMeasurement);
        await _unitOfMeasurementRepository.CreateAsync(unitOfMeasurementEntity);
        return _mapper.Map<UnitOfMeasurementDto>(unitOfMeasurementEntity);
	}

    public async Task UpdateAsync(int unitOfMeasurementId, UpdateUnitOfMeasurementDto unitOfMeasurement)
    {
        ThrowIfReceiptNotExist(unitOfMeasurementId);
        
        var unitOfMeasurementEntity = _mapper.Map<UnitOfMeasurement>(unitOfMeasurement);
        unitOfMeasurementEntity.Id = unitOfMeasurementId;
        
        await _unitOfMeasurementRepository.UpdateAsync(unitOfMeasurementEntity);
    }

    public async Task DeleteAsync(int unitOfMeasurementId)
    {
        ThrowIfReceiptNotExist(unitOfMeasurementId);
        await _unitOfMeasurementRepository.DeleteAsync(unitOfMeasurementId);
    }

    private void ThrowIfReceiptNotExist(int categoryId)
    {

    }
}