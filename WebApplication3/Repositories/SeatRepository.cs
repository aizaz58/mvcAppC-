using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication3.Data;
using WebApplication3.Interfaces;
using WebApplication3.Models;
using WebApplication3.Repositories;

namespace WebApplication3.Repositories;

public class SeatRepository:Genericrepository<Seat>,ISeatRepository
{
    private readonly ApplicationDbContext _context;

    public SeatRepository(ApplicationDbContext context):base(context)
    {
        this._context = context;
    }

    public IEnumerable<Seat> IncludeOther(Expression<Func<Seat, Enclosure>> expression)
    {
       return _context.Seats.Include(expression);
    }
}
