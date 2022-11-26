namespace Services.Exceptions;

public sealed class ReceiptPositionNotFoundException : NotFoundException
{
	public ReceiptPositionNotFoundException(int reciptId, int positionId)
		: base($"Receipt position with id {reciptId} in receipt with id {positionId} not found.") { }
}