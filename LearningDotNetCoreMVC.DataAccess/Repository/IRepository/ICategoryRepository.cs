using LearningDotNetCoreMVC.Models.Models;

namespace LearningDotNetCoreMVC.DataAccess.Repository.IRepository;

public interface ICategoryRepository : IBaseRepository<Category>
{
    public Category Update(Category updatedObject);
    public void Save();

}