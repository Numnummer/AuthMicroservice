using AuthMicroservice.Abstractions;
using AuthMicroservice.Options;
using Microsoft.Extensions.Options;
using System.Diagnostics.Metrics;
using System.Net;
using System.Net.Mail;

namespace AuthMicroservice.Services
{
    public class EmailService(IOptionsMonitor<MailSettings> mailOptions) : IEmailService
    {
        public async Task<bool> SendEmailAsync(string email, string body, string subject)
        {
            using var mail =
                new MailMessage(mailOptions.CurrentValue.Sender,
                email, subject, body);
            using var smtpClient = new SmtpClient(mailOptions.CurrentValue.Server,
                mailOptions.CurrentValue.Port);
            smtpClient.Credentials =
                new NetworkCredential(mailOptions.CurrentValue.Sender,
                mailOptions.CurrentValue.Password);
            smtpClient.EnableSsl = true;

            try
            {
                await smtpClient.SendMailAsync(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
