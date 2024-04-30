using CodingAssessment.Models;
using CodingAssessment.Repository;
using CodingAssessment.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net.Mail;
using static CodingAssessment.Services.EmailService;

namespace CodingAssessmentUnitTest.Services
{
    public class EmailServiceTests
    {
        [Fact]
        public async Task SendEmailAsync_EmailSent_ReturnsTrue()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<FoodAndDrugAdministrationRepository>>();
            var smtpClientMock = new Mock<ISmtpClient>();
            var emailObject = new Food(); // Replace Food with the actual type of your email object
            var emailService = new EmailService(loggerMock.Object, smtpClientMock.Object);

            // Act
            var result = await emailService.SendEmailAsync(emailObject);

            // Assert
            Assert.True(result);
        }
    }

}
