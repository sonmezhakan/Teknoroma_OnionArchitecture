namespace Teknoroma.Application.Services.EmailServices
{
	public interface IMailService
	{
		Task SendMailAsync(string subject, string? textBody, string? htmlBody, string toEmail);
	}
}
