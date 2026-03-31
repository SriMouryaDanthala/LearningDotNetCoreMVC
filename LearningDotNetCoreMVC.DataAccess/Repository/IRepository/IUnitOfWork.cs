namespace LearningDotNetCoreMVC.DataAccess.Repository.IRepository;

public interface IUnitOfWork
{
    ICategoryRepository Category { get; }

    public void Save();
}