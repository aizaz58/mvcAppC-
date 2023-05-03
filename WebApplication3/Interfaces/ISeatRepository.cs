using System.Linq.Expressions;
using WebApplication3.Models;

namespace WebApplication3.Repositories
{
    public interface ISeatRepository:IGenericRepository<Seat>
    {

        public IEnumerable<Seat> IncludeOther(Expression<Func<Seat, Enclosure>> expression);
    }
}
