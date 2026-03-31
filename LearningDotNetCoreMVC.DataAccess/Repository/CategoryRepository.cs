using LearningDotNetCoreMVC.DataAccess.Data;
using LearningDotNetCoreMVC.DataAccess.Repository.IRepository;
using LearningDotNetCoreMVC.Models.Models;

namespace LearningDotNetCoreMVC.DataAccess.Repository;

public class CategoryRepository : BaseRepository<Category> , ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
        _dbContext = context;
    }

    public Category Update(Category updatedObject)
    {
        _dbset.Update(updatedObject);
        return updatedObject;
    }
}