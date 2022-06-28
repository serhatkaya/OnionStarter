namespace OnionStarter.Application.Interfaces.Services;

public interface IEmailService
{
    bool Send(string to, string message);
}