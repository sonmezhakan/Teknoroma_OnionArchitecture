namespace Teknoroma.Application.Services.EmailService
{
    public class Mail
    {
        public string Subject { get; set; }
        public string? TextBody { get; set; }
        public string? HtmlBody { get; set; }
        public string ToEmail { get; set; }
    }
}
