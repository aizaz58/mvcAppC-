using System.Linq.Expressions;
using WebApplication3.Models;
using WebApplication3.Repositories;

namespace WebApplication3.Interfaces
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {

        public IQueryable<Ticket> IncludeOther(Expression<Func<Ticket,Match>> expression);
    }
}













