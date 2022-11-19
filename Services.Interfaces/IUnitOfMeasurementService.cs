using DataTransferObjects;

namespace Services.Interfaces;

public interface IUnitOfMeasurementService
{
    Task<UnitOfMeasurementDto> CreateAsync(NewUnitOfMeasurementDto unitOfMeasurement);
    Task<IReadOnlyCollection<UnitOfMeasurementDto>> GetAllAsync();
    Task UpdateAsync(int id, UpdateUnitOfMeasurementDto unitOfMeasurement);
    Task DeleteAsync(int id);
}