using System.Linq.Expressions;
using WebApplication3.Models;

namespace WebApplication3.Interfaces;

public interface IMatchRepository:IGenericRepository<Match>
{
    public IEnumerable<Match> IncludeOther(Expression<Func<Match, Stadium>> expression);
}
