using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Repositories;

namespace WebApplication3.Implementation
{
    public class EnclosureRepository:Genericrepository<Enclosure>, IEnclosureRepository
    {
        private readonly ApplicationDbContext _context;

        public EnclosureRepository(ApplicationDbContext context):base(context)
        {
            this._context = context;
        }

        
public void IncludeOther()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Enclosure> IncludeOther(Expression<Func<Enclosure, Stadium>> expression)=>
        

             _context.Enclosures.Include(expression);
            

        
    }
}
