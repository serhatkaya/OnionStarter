using OnionStarter.Application.Interfaces.Services;

namespace OnionStarter.Infrastructure.Services;

public class EmailService : IEmailService
{
    public bool Send(string to, string message)
    {
        Console.WriteLine("mail sent");
        return true;
    }
}