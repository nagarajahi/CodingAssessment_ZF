using CodingAssessment.AppDbContext;
using CodingAssessment.Controllers;
using CodingAssessment.Models;
using CodingAssessment.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CodingAssessment.Repository
{
    public class FoodAndDrugAdministrationRepository : IFoodAndDrugAdministrationRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<FoodAndDrugAdministrationRepository> _logger;

        public FoodAndDrugAdministrationRepository(IApplicationDbContext context, ILogger<FoodAndDrugAdministrationRepository> logger)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<FoodInfoResponse> GetAllFoodAndDrug(int? pageNumber, int? pageSize)
        {
            FoodInfoResponse foodInfoResponse = new FoodInfoResponse();
            try
            {
                var foodEnforcements = await _context.FoodEnforcements.OrderBy(x => x.id)
                        .Skip((pageNumber.Value - 1) * pageSize.Value)
                        .Take(pageSize.Value)
                        .ToListAsync();
                foodInfoResponse.foods = foodEnforcements;
                foodInfoResponse.totalRecords = _context.FoodEnforcements.Count();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
            }
            return foodInfoResponse;
        }

        public async Task<bool> InsertFoodAndDrug(FoodInfo? foodInfo,CancellationToken cancellationToken=default)
        {
            try
            {
                _context.FoodEnforcements.AddRange(foodInfo.results);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return false;
            }
        }

    }
}
