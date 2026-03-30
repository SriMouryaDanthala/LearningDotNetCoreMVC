using LearningDotNetCoreMVC.DataAccess.Data;
using LearningDotNetCoreMVC.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LearningDotNetCoreMVC.DataAccess.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly ApplicationDbContext _dbcontext;
    protected readonly DbSet<T> _dbset;
    
    public BaseRepository(ApplicationDbContext context)
    {
        _dbcontext = context;
        _dbset = _dbcontext.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbset.ToList();
    }

    public IEnumerable<T> Get(Func<T, bool> filter)
    {
        var queryResults = _dbset.Where(filter);
        return queryResults.ToList();
    }

    public void Add(T Data)
    {
        _dbset.Add(Data);
    }

    public void Delete(T Data)
    {
        if (null != Data)
        {
            _dbset.Remove(Data);
        }
        else
        {
            throw new NullReferenceException("Provided object is null");
        }
        
    }

    public void DeleteRange(IEnumerable<T> range)
    {
        if (range.Any())
        {
            _dbset.RemoveRange(range);
        }
        else
        {
            throw new Exception("No elements in the range passed.");
        }
    }
}