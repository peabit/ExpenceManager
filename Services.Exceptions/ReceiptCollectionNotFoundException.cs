namespace Services.Exceptions;

public sealed class ReceiptCollectionNotFoundException : NotFoundException
{
	public ReceiptCollectionNotFoundException() 
		: base("Receipts not found.") {}
}