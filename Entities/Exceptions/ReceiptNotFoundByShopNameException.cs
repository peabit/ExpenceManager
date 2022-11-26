namespace Entities.Exceptions;

public sealed class ReceiptNotFoundByShopNameException : NotFoundException
{
	public ReceiptNotFoundByShopNameException(string shopName)
		: base($"Receipt with shop {shopName} not found.") {}
}