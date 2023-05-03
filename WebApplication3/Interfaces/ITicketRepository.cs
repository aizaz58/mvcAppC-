using System.Linq.Expressions;
using WebApplication3.Models;

namespace WebApplication3.Repositories
{
    public interface ITicketRepository:IGenericRepository<Ticket>
    {

        public IEnumerable<Ticket> IncludeOther(Expression<Func<Ticket, Match>> expression);
    }
}
