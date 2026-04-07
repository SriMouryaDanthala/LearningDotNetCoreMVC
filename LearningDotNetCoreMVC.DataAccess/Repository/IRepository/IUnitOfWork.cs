namespace LearningDotNetCoreMVC.DataAccess.Repository.IRepository;

public interface IUnitOfWork
{
    ICategoryRepository Category { get; }
    IProductRepository Product { get; }


    public void Save();
}