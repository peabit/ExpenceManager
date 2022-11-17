using Entities;

namespace Repositories;

public class UnitOfMeasurementRepository : RepositoryBase<UnitOfMeasurement>
{
    public UnitOfMeasurementRepository(RepositoryContext context) : base(context) { }
}