using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Repositories;

namespace WebApplication3.Implementation
{
    public class MatchRepository:Genericrepository<Match>,IMatchRepository
    {
        public MatchRepository(ApplicationDbContext context):base(context)
        {
            
        }
    }
}
