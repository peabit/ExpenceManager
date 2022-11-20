using DataTransferObjects;

namespace Services.Interfaces;

public interface IUnitOfMeasurementService
{
    Task<IReadOnlyCollection<UnitOfMeasurementDto>> GetAllAsync();
    Task<UnitOfMeasurementDto> CreateAsync(NewUnitOfMeasurementDto unitOfMeasurement);
    Task UpdateAsync(int id, UpdateUnitOfMeasurementDto unitOfMeasurement);
    Task DeleteAsync(int id);
}