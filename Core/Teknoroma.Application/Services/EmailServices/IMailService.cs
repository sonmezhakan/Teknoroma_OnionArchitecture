namespace Teknoroma.Application.Services.EmailService
{
    public interface IMailService
    {
        Task SendMail(Mail mail);
    }
}
