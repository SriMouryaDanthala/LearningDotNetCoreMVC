using LearningDotNetCoreMVC.DataAccess.Data;
using LearningDotNetCoreMVC.DataAccess.Repository.IRepository;

namespace LearningDotNetCoreMVC.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    public ICategoryRepository Category { get; private set; }
    public IProductRepository Product { get; private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _dbContext = context;
        Category = new CategoryRepository(_dbContext);
        Product = new ProductRepository(_dbContext);
    }
    

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}