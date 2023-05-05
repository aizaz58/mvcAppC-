using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication3.Data;
using WebApplication3.Interfaces;
using WebApplication3.Models;


namespace WebApplication3.Repositories;

public class EnclosureRepository:Genericrepository<Enclosure>,IEnclosureRepository
{
    private readonly ApplicationDbContext _context;

    public EnclosureRepository(ApplicationDbContext context):base(context)
    {
        this._context = context;
    }

    


    public IEnumerable<Enclosure> IncludeOther(Expression<Func<Enclosure, Stadium>> expression)=>
    

         _context.Enclosures.Include(expression);
        

    
}
