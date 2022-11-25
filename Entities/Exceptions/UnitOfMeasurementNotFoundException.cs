namespace Entities.Exceptions;

public sealed class UnitOfMeasurementNotFoundException : NotFoundException
{
	public UnitOfMeasurementNotFoundException(int id)
		: base($"Unit of measurement with id: {id} doesn`t exist in the database.") { }
}