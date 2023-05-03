using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Repositories;

namespace WebApplication3.Implementation
{
    public class MatchRepository:Genericrepository<Match>,IMatchRepository
    {
        private readonly ApplicationDbContext _context;

        public MatchRepository(ApplicationDbContext context):base(context)
        {
            this._context = context;
        }

        public IEnumerable<Match> IncludeOther(Expression<Func<Match, Stadium>> expression)
        {
           return _context.Matches.Include(expression);
        }
    }
}
