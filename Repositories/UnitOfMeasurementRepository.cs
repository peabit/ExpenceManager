using Entities;

namespace Repositories;

public sealed class UnitOfMeasurementRepository : RepositoryBase<UnitOfMeasurement>
{
    public UnitOfMeasurementRepository(RepositoryContext context) : base(context) { }
}