using Services.Interfaces;
using Entities;
using Repositories.Interfaces;
using DataTransferObjects;

namespace Services;

public class UnitOfMeasurementService : ServiceBase<UnitOfMeasurement>, IUnitOfMeasurementService
{
	public UnitOfMeasurementService(IRepository<UnitOfMeasurement> repository) : base(repository) { }

	public Task<UnitOfMeasurementDto> Create(NewUnitOfMeasurementDto unitOfMeasurement)
	{
		throw new NotImplementedException();
	}

	public Task Delete(int id)
	{
		throw new NotImplementedException();
	}

	public Task<IReadOnlyCollection<UnitOfMeasurementDto>> GetAll()
	{
		throw new NotImplementedException();
	}

	public Task Update(int id, UpdateUnitOfMeasurementDto unitOfMeasurement)
	{
		throw new NotImplementedException();
	}
}