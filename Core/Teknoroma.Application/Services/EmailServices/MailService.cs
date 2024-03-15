using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;

namespace Teknoroma.Application.Services.EmailServices
{
	public class MailService:IMailService
	{
		private readonly IConfiguration _configuration;

		public MailService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task SendMailAsync(string subject, string? textBody, string? htmlBody, string toEmail)
		{
			MailMessage sender = new MailMessage();
			sender.From = new MailAddress(_configuration["EmailSettings:Username"], subject);
			sender.Subject = subject;
			sender.Body = $@"{textBody} <br> {htmlBody}";
			sender.IsBodyHtml = true;
			sender.To.Add(toEmail);


			SmtpClient smtpClient = new SmtpClient();
			smtpClient.Credentials = new NetworkCredential(_configuration["EmailSettings:Username"], _configuration["EmailSettings:Password"]);
			smtpClient.Port = int.Parse(_configuration["EmailSettings:SmtpPort"]);
			smtpClient.Host = _configuration["EmailSettings:SmtpServer"];
			smtpClient.EnableSsl = true;
			await smtpClient.SendMailAsync(sender);
		}
	}
}
