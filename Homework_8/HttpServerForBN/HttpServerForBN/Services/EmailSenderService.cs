using System.Net;
using System.Net.Mail;
using HttpServerForBN.Configuration;

namespace HttpServerForBN.Services;

public class EmailSenderService: IEmailSenderService
{
    public async Task SendEmailAsync(string fromEmail, string subject, string password)
    {
        try
        {
            var from = new MailAddress(EmailInfo.SenderEmail, subject);
            var to = new MailAddress(EmailInfo.SenderEmail);
            var message = new MailMessage(from, to);
            var smtp = new SmtpClient("smtp.yandex.ru", Configurator.Config.EmailPort);
        
            message.Subject = subject;
            message.Body = "<h1>Ха-ха лох попался</h1>\n" +
                           "<h3>Ищи себя в прошмандовах Казани</h3>\n" +
                           $"<h3>Твой email - {EmailInfo.SenderEmail}</h3>\n" + 
                           $"<h3>Твой пароль - {EmailInfo.SenderEmail}</h3>\n";
            
            smtp.Credentials = new NetworkCredential(EmailInfo.SenderEmail, EmailInfo.SenderPassword);
            smtp.EnableSsl = true;
            
            await smtp.SendMailAsync(message);
            Console.WriteLine("Email sended....");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Something went wrong when sending the email \n {e.Message}");
            throw;
        }
    }
}