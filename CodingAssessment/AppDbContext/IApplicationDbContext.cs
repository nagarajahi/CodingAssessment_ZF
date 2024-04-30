using CodingAssessment.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingAssessment.AppDbContext
{
    public interface IApplicationDbContext
    {
        DbSet<Food> FoodEnforcements { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
