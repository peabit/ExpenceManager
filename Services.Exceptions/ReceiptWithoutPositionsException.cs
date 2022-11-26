namespace Services.Exceptions;

public sealed class ReceiptWithoutPositionsException : ServiceException
{
    public ReceiptWithoutPositionsException() 
        : base("Receipt without positions") { }
}
