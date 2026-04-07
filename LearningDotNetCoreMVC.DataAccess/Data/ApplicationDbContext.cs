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

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "The Alchemist", Description = "A journey of self-discovery", Author = "Paulo Coelho", ISBN = "ISBN001", Price = 499, PriceForFifty = 450, PriceForHundred = 400 },
                new Product { Id = 2, Name = "Clean Code", Description = "A handbook of agile software craftsmanship", Author = "Robert C. Martin", ISBN = "ISBN002", Price = 999, PriceForFifty = 900, PriceForHundred = 850 },
                new Product { Id = 3, Name = "The Pragmatic Programmer", Description = "Your journey to mastery", Author = "Andrew Hunt", ISBN = "ISBN003", Price = 899, PriceForFifty = 800, PriceForHundred = 750 },
                new Product { Id = 4, Name = "Atomic Habits", Description = "An easy & proven way to build good habits", Author = "James Clear", ISBN = "ISBN004", Price = 699, PriceForFifty = 650, PriceForHundred = 600 },
                new Product { Id = 5, Name = "Deep Work", Description = "Rules for focused success", Author = "Cal Newport", ISBN = "ISBN005", Price = 799, PriceForFifty = 720, PriceForHundred = 680 },
                new Product { Id = 6, Name = "Rich Dad Poor Dad", Description = "What the rich teach their kids", Author = "Robert Kiyosaki", ISBN = "ISBN006", Price = 599, PriceForFifty = 550, PriceForHundred = 500 },
                new Product { Id = 7, Name = "Zero to One", Description = "Notes on startups and building the future", Author = "Peter Thiel", ISBN = "ISBN007", Price = 749, PriceForFifty = 700, PriceForHundred = 650 },
                new Product { Id = 8, Name = "Think and Grow Rich", Description = "Classic personal success guide", Author = "Napoleon Hill", ISBN = "ISBN008", Price = 399, PriceForFifty = 350, PriceForHundred = 300 },
                new Product { Id = 9, Name = "Sapiens", Description = "A brief history of humankind", Author = "Yuval Noah Harari", ISBN = "ISBN009", Price = 1099, PriceForFifty = 1000, PriceForHundred = 950 },
                new Product { Id = 10, Name = "The Lean Startup", Description = "How today's entrepreneurs use continuous innovation", Author = "Eric Ries", ISBN = "ISBN010", Price = 899, PriceForFifty = 820, PriceForHundred = 780 }
            );
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        
    }
}
