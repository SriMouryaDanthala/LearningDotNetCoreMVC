namespace LearningDotNetCoreMVC.DataAccess.Repository.IRepository;

public interface IBaseRepository<T> where T: class
{
    public IEnumerable<T> GetAll(string? relations = null);
    public IEnumerable<T> Get(Func<T,bool> filter, string? relations = null);
    public void Add(T Data);
    public void Delete(T Data);
    public void DeleteRange(IEnumerable<T> range);

}