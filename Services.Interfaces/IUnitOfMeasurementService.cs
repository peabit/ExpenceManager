using DataTransferObjects;

namespace Services.Interfaces;

public interface IUnitOfMeasurementService
{
    Task<UnitOfMeasurementDto> Create(NewUnitOfMeasurementDto unitOfMeasurement);
    Task<IReadOnlyCollection<UnitOfMeasurementDto>> GetAll();
    Task Update(int id, UpdateUnitOfMeasurementDto unitOfMeasurement);
    Task Delete(int id);
}