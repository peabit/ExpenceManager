namespace Entities.Exceptions;

public sealed class ReceiptNotFoundByPeriodException : NotFoundException
{
	public ReceiptNotFoundByPeriodException(DateTime from, DateTime to)
		: base($"Receipts from {from} to {to} not found.") { }
}