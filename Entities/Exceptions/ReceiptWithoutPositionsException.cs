namespace Entities.Exceptions;

public sealed class ReceiptWithoutPositionsException : Exception
{
    public ReceiptWithoutPositionsException() 
        : base("Receipt without positions") { }
}
