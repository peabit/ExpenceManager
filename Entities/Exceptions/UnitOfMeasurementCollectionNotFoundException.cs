namespace Entities.Exceptions;

public sealed class UnitOfMeasurementCollectionNotFoundException : NotFoundException
{
	public UnitOfMeasurementCollectionNotFoundException()
		: base("Units of measurement not found") { }
}