using Core.Interfaces;
using MailKit.Security;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Core.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly IConfiguration configuration;

        public EmailSenderService(IConfiguration configuration) 
        {
            this.configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Sender Name", configuration["EmailSettings:From"]));
            emailMessage.To.Add(new MailboxAddress("Recipient Name", email));
            emailMessage.Subject = subject;

            emailMessage.Body = new TextPart("plain")
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(
                        configuration["SMTP:Server"], 
                        int.Parse(configuration["SMTP:Port"]),
                        SecureSocketOptions.StartTls);

                    await client.AuthenticateAsync(
                        configuration["EmailSettings:User"],
                        configuration["EmailSettings:Password"]
                    );

                    await client.SendAsync(emailMessage);
                    Console.WriteLine("Email sent successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erorr: ${ex.Message}");
                }
                finally
                {
                    await client.DisconnectAsync(true);
                }
            }
        }
    }
}
