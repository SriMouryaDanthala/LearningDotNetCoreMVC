using LearningDotNetCoreMVC.Models.Models;

namespace LearningDotNetCoreMVC.DataAccess.Repository.IRepository;

public interface IProductRepository : IBaseRepository<Product>
{
    public Product Update(Product updatedObject);
}