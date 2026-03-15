using LearningDotNetCoreMVC.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningDotNetCoreMVC.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, Name = "Action", DisplayOrder = 1 },
                new Category { ID = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { ID = 3, Name = "SelfHelp", DisplayOrder = 3 }
            );
        }

        public DbSet<Category> Categories { get; set; }

        
    }
}
