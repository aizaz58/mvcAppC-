using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Interfaces;


namespace WebApplication3.Repositories;

public class Genericrepository<T>:IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;
    
    public Genericrepository(ApplicationDbContext context)
    {
        this._context = context;
        this._dbSet=_context.Set<T>();
    }

    public void Add(T entity)
    {
       _dbSet.Add(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public IEnumerable<T> GetAll()
    {
      return  _dbSet.ToList();
    }

    public T GetById(int? id)
    {
        return _dbSet.Find(id);
    }

    public void Update(T entity)
    {
         _dbSet.Update(entity);
        
    }
}
