namespace Services.Exceptions;

public abstract class NotFoundException : ServiceException
{
	public NotFoundException(string message) : base(message) { }
}