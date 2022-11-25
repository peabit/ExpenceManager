using AutoMapper;
using Entities;
using Entities.Exceptions;
using DataTransferObjects;
using Repositories.Interfaces;
using Services.Interfaces;

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

        if (uoms.Count == 0)
        {
            throw new UnitOfMeasurementCollectionNotFoundException();
        }

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
        if (!_repository.UnitOfMeasurement.Contains(u => u.Id == id))
        {
            throw new UnitOfMeasurementNotFoundException(id);
        }

        var uomEntity = _mapper.Map<UnitOfMeasurement>(uom);
        uomEntity.Id = id;
        
        await _repository.UnitOfMeasurement.UpdateAsync(uomEntity);
    }

    public async Task DeleteAsync(int id)
    {
        var uom = await _repository.UnitOfMeasurement.GetFirstAsync( u => u.Id == id);

        if (uom is null)
        {
            throw new UnitOfMeasurementNotFoundException(id);
        }

        await _repository.UnitOfMeasurement.DeleteAsync(uom);
    }
}