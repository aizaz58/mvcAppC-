using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication3.Data;
using WebApplication3.Interfaces;
using WebApplication3.Models;


namespace WebApplication3.Repositories;

public class TicketRepository:Genericrepository<Ticket>,ITicketRepository

{
    private readonly ApplicationDbContext _context;

    public TicketRepository(ApplicationDbContext context):base(context)
    {
        this._context = context;
    }

    public IQueryable<Ticket> IncludeOther(Expression<Func<Ticket,Match>> expression)
    {

        return _context.Tickets.Include(expression);
    }
}
