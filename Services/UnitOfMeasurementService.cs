using AutoMapper;
using Services.Interfaces;
using Entities;
using Repositories.Interfaces;
using DataTransferObjects;
using Repositories;

namespace Services;

public sealed class UnitOfMeasurementService : IUnitOfMeasurementService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UnitOfMeasurementService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<UnitOfMeasurementDto>> GetAllAsync()
    {
        var uoms = await _repository.UnitOfMeasurement.GetAllAsync();
        return _mapper.Map<IReadOnlyCollection<UnitOfMeasurementDto>>(uoms);
    }

    public async Task<UnitOfMeasurementDto> CreateAsync(NewUnitOfMeasurementDto uom)
	{
        var uomEntity = _mapper.Map<UnitOfMeasurement>(uom);
        await _repository.UnitOfMeasurement.CreateAsync(uomEntity);
        return _mapper.Map<UnitOfMeasurementDto>(uomEntity);
	}

    public async Task UpdateAsync(int id, UpdateUnitOfMeasurementDto uom)
    {
        var uomEntity = _mapper.Map<UnitOfMeasurement>(uom);
        uomEntity.Id = id;
        
        await _repository.UnitOfMeasurement.UpdateAsync(uomEntity);
    }

    public async Task DeleteAsync(int id)
    {
        var uom = await _repository.UnitOfMeasurement.GetFirstAsync( u => u.Id == id);
        await _repository.UnitOfMeasurement.DeleteAsync(uom);
    }
}