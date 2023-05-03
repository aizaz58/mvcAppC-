using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Repositories;

namespace WebApplication3.Implementation
{
    public class TicketRepository:Genericrepository<Ticket>,ITicketRepository

    {
        private readonly ApplicationDbContext _context;

        public TicketRepository(ApplicationDbContext context):base(context)
        {
            this._context = context;
        }

        public IEnumerable<Ticket> IncludeOther(Expression<Func<Ticket, Match>> expression)
        {
            return _context.Tickets.Include(expression);
        }
    }
}
