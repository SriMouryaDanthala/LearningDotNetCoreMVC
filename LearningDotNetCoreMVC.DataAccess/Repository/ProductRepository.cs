using LearningDotNetCoreMVC.DataAccess.Data;
using LearningDotNetCoreMVC.DataAccess.Repository.IRepository;
using LearningDotNetCoreMVC.Models.Models;

namespace LearningDotNetCoreMVC.DataAccess.Repository;

public class ProductRepository : BaseRepository<Product>,IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository (ApplicationDbContext context) : base(context)
    {
        _dbContext = context;
    }

    public Product Update(Product updatedObject)
    {
        _dbset.Update(updatedObject);
        _dbContext.SaveChanges();
        return updatedObject;
    }
}