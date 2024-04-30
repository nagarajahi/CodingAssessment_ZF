using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodingAssessment.Services;
using CodingAssessment.Repository.IRepository;
using CodingAssessment.Controllers;
using Moq;
using CodingAssessment.Models;
using CodingAssessment.AppDbContext;
using CodingAssessment.Repository;
using Microsoft.EntityFrameworkCore;

namespace CodingAssessmentUnitTest.FoodAndDrugAdministrationControllerTest
{
    public class EmailFoodAndDrugAdministrationControllerTests
    {
        [Fact]
        public async Task Getlistoffoodenforcementandsendemail_ReturnsOkResult()
        {
            // Arrange
            var mockEmailService = new Mock<IEmailService>();

            mockEmailService.Setup(service => service.SendEmailAsync(It.IsAny<Food>()))
                .ReturnsAsync(true);

            var controller = new EmailFoodAndDrugAdministrationController(
                mockEmailService.Object);

            // Act
            var result = await controller.Getlistoffoodenforcementandsendemail();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.True((bool)okResult.Value);

            mockEmailService.Verify(service => service.SendEmailAsync(It.IsAny<Food>()), Times.Once);
        }

    }
}