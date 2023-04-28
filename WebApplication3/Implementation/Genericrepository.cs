using WebApplication3.Data;
using WebApplication3.Repositories;

namespace WebApplication3.Implementation
{
    public class Genericrepository<T>:IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Genericrepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Add(T entity)
        {
           _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
        _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
          return  _context.Set<T>().ToList();
        }

        public T GetById(int? id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
             _context.Set<T>().Update(entity);
            
        }
    }
}
