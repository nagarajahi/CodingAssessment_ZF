using CodingAssessment.AppDbContext;
using CodingAssessment.Models;
using CodingAssessment.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAssessmentUnitTest.Repository
{
    public class FoodAndDrugAdministrationRepositoryTests
    {
        [Fact]
        public async Task GetAllFoodAndDrug_ReturnsCorrectResponse()
        {
           // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.FoodEnforcements.Add(new Food { id = 1,  address_1 = "Food 1" });
                context.FoodEnforcements.Add(new Food { id = 2, address_2 = "Food 2" });
                context.SaveChanges();
            }

            var mockLogger = new Mock<ILogger<FoodAndDrugAdministrationRepository>>();

            using (var context = new ApplicationDbContext(options))
            {
                var repository = new FoodAndDrugAdministrationRepository(context, mockLogger.Object);

                // Act
                var response = await repository.GetAllFoodAndDrug(1, 2);

                // Assert
                Assert.NotNull(response);
                Assert.IsType<FoodInfoResponse>(response);
                Assert.Equal(2, response.totalRecords);
                Assert.Equal(2, response.foods.Count);
            }
        }

        [Fact]
        public async Task InsertFoodAndDrug_ReturnsTrueOnSuccess()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var mockLogger = new Mock<ILogger<FoodAndDrugAdministrationRepository>>();

            using (var context = new ApplicationDbContext(options))
            {
                var repository = new FoodAndDrugAdministrationRepository(context, mockLogger.Object);
                var foodInfo = new FoodInfo { results = new List<Food> { new Food { id = new Random().Next(100000), address_1 = "Food 1" } } };

                // Act
                var result = await repository.InsertFoodAndDrug(foodInfo);

                // Assert
                Assert.True(result);
            }
        }
    }

}
