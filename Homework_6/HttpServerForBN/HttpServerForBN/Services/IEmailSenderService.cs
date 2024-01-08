namespace HttpServerForBN.Services;

public interface IEmailSenderService
{
    Task SendEmailAsync(string fromEmail, string subject, string password);
}