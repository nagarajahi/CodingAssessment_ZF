using CodingAssessment.Models;

namespace CodingAssessment.Repository.IRepository
{
    public interface IFoodAndDrugAdministrationRepository
    {
        Task<FoodInfoResponse> GetAllFoodAndDrug(int? pageNumber, int? pageSize);
        Task<bool> InsertFoodAndDrug(FoodInfo? foodInfo, CancellationToken cancellationToken);
    }
}
