
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Teknoroma.Application.Services.EmailService
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMail(Mail mail)
        {
            MailMessage sender = new MailMessage();
            sender.From = new MailAddress(_configuration["EmailSettings:Username"], mail.Subject);
            sender.Subject = mail.Subject;
            sender.Body = $@"{mail.TextBody} <br> {mail.HtmlBody}";
            sender.IsBodyHtml = true;
            sender.To.Add(mail.ToEmail);


            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(_configuration["EmailSettings:Username"], _configuration["EmailSettings:Password"]);
            smtpClient.Port = int.Parse(_configuration["EmailSettings:SmtpPort"]);
            smtpClient.Host = _configuration["EmailSettings:SmtpServer"];
            smtpClient.EnableSsl = true;
            smtpClient.Send(sender);
        }
    }
}
