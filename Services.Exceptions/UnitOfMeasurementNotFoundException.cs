namespace Services.Exceptions;

public sealed class UnitOfMeasurementNotFoundException : NotFoundException
{
	public UnitOfMeasurementNotFoundException(int id)
		: base($"Unit of measurement with id {id} not found.") { }
}