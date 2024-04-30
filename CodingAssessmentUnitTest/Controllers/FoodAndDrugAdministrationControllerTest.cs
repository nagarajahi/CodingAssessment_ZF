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
    public class FoodAndDrugAdministrationControllerTests
    {
       
        [Fact]
        public async Task Processlistoffoodenforcement_ReturnsOkResult()
        {
            // Arrange
            var mockRepository = new Mock<IFoodAndDrugAdministrationRepository>();
            var mockLogger = new Mock<ILogger<FoodAndDrugAdministrationController>>();

            mockRepository.Setup(repo => repo.InsertFoodAndDrug(It.IsAny<FoodInfo>(), new CancellationToken()))
                .ReturnsAsync(true);

            var controller = new FoodAndDrugAdministrationController(
                 mockRepository.Object, mockLogger.Object);

            // Act
            var result = await controller.Processlistoffoodenforcement();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.True((bool)okResult?.Value);

            mockRepository.Verify(repo => repo.InsertFoodAndDrug(It.IsAny<FoodInfo>(), new CancellationToken()), Times.Once);
        }

        [Fact]
        public async Task Getlistoffoodenforcement_ReturnsOkResult()
        {
            // Arrange
            var mockEmailService = new Mock<IEmailService>();
            var mockRepository = new Mock<IFoodAndDrugAdministrationRepository>();
            var mockLogger = new Mock<ILogger<FoodAndDrugAdministrationController>>();

            mockRepository.Setup(service => service.GetAllFoodAndDrug(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(new FoodInfoResponse { foods = new List<Food>(), totalRecords = 0 });

            var controller = new FoodAndDrugAdministrationController(
                 mockRepository.Object, mockLogger.Object);

            // Act
            var result = await controller.Getlistoffoodenforcement();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.NotNull(okResult.Value);

        }
       
    }
}