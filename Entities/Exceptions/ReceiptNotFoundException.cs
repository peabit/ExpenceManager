namespace Entities.Exceptions;

public sealed class ReceiptNotFoundException : NotFoundException
{
	public ReceiptNotFoundException(int id) 
		: base($"Receipt with id {id} not found.") { }
}