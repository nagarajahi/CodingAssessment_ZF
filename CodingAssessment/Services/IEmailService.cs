using CodingAssessment.Models;

namespace CodingAssessment.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(Food? emailObject);
    }
}
