namespace OnionStarter.Application.Exceptions;

public class AppException : Exception
{
    public AppException() : base("Unexpected error")
    { }

    public AppException(string message) : base(message)
    { }

    public AppException(Exception exception) : this(exception.Message)
    { }
}