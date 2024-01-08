using HttpServerForBN.Attributes;
using HttpServerForBN.Model;
using HttpServerForBN.Services;

namespace HttpServerForBN.Controllers;

[HttpController("accounts")]
public class AccountsController
{
    public AccountsController() { }

    [Post("SendToEmail")]
    public async void SendToEmail(string emailFromUser, string passwordFromUser)
    {
        var service = new EmailSenderService();
        await service.SendEmailAsync(emailFromUser, "", passwordFromUser);
        Console.WriteLine("email sended...");
    }

    [Post("GetEmailList")]
    public string GetEmailList()
    {
        var htmlCode = "<html><head></head><body><h1>owhogeojigo</h1></body></html>";
        return htmlCode;
    }
    
    [Post("GetAccountsList")]
    public Account[] GetAccountsList()
    {
        var accounts = new[]
        {
            new Account() { Email = "email-1", Password = "password-1" },
            new Account() { Email = "email-2", Password = "password-2" }
        };
        return accounts;
    }

    [Post("SendToEmail")]
    public void Select()
    {
        Console.WriteLine("Выделено");
    }
}