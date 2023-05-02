using System.Linq.Expressions;
using WebApplication3.Models;

namespace WebApplication3.Repositories
{
    public interface IEnclosureRepository:IGenericRepository<Enclosure>
    {

       public IEnumerable<Enclosure> IncludeOther(Expression<Func<Enclosure, Stadium>> expression);
        
        
    }
}
