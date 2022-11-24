using AutoMapper;
using Services.Interfaces;
using Entities;
using Repositories.Interfaces;
using DataTransferObjects;

namespace Services;

public sealed class UnitOfMeasurementService : IUnitOfMeasurementService
{
    private readonly IRepository<UnitOfMeasurement> _repository;
    private readonly IMapper _mapper;

    public UnitOfMeasurementService(IRepository<UnitOfMeasurement> uomRepository, IMapper mapper)
    {
        _repository = uomRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<UnitOfMeasurementDto>> GetAllAsync()
    {
        var uoms = await _repository.GetAllAsync();
        return _mapper.Map<IReadOnlyCollection<UnitOfMeasurementDto>>(uoms);
    }

    public async Task<UnitOfMeasurementDto> CreateAsync(NewUnitOfMeasurementDto uom)
	{
        var uomEntity = _mapper.Map<UnitOfMeasurement>(uom);
        await _repository.CreateAsync(uomEntity);
        return _mapper.Map<UnitOfMeasurementDto>(uomEntity);
	}

    public async Task UpdateAsync(int id, UpdateUnitOfMeasurementDto uom)
    {
        var uomEntity = _mapper.Map<UnitOfMeasurement>(uom);
        uomEntity.Id = id;
        
        await _repository.UpdateAsync(uomEntity);
    }

    public async Task DeleteAsync(int id)
    {
        var uom = await _repository.GetFirstAsync( u => u.Id == id);
        await _repository.DeleteAsync(uom);
    }
}