namespace Services.Exceptions;

public abstract class ServiceException : Exception
{
    public ServiceException(string message)
        : base(message) { }
}