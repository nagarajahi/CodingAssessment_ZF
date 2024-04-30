using CodingAssessment.Models;
using System.Net.Mail;
using System.Net;
using CodingAssessment.Repository;

namespace CodingAssessment.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<FoodAndDrugAdministrationRepository> _logger;
        private readonly ISmtpClient _smtpClient;

        public EmailService(ILogger<FoodAndDrugAdministrationRepository> logger, ISmtpClient smtpClient)
        {
            _logger = logger;
            _smtpClient = smtpClient;
        }

        public async Task<bool> SendEmailAsync(Food? emailObject)
        {
            var fromAddress = new MailAddress("your-email@gmail.com", "Your Name");
            var toAddress = new MailAddress("recipient@example.com", "Recipient Name");
            const string fromPassword = "your-password";
            const string subject = "Subject of the Email";

            try
            {
                string body = Newtonsoft.Json.JsonConvert.SerializeObject(emailObject);
                var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                };

                await _smtpClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return false;
            }

            Console.WriteLine("Email sent successfully.");
            return true;
        }

        public interface ISmtpClient
        {
            Task SendMailAsync(MailMessage message);
        }

        public class SmtpClientWrapper : ISmtpClient
        {
            private readonly SmtpClient _smtpClient;

            public SmtpClientWrapper(SmtpClient smtpClient)
            {
                _smtpClient = smtpClient;
            }

            public Task SendMailAsync(MailMessage message)
            {
                return _smtpClient.SendMailAsync(message);
            }
        }

    }
}
