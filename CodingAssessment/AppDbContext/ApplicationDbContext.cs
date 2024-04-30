using CodingAssessment.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingAssessment.AppDbContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Food> FoodEnforcements { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "FoodEnforcement");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>(b =>
            {
               b.HasKey(x=>x.id);
            });
        }
    }


}
