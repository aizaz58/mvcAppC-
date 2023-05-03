using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Repositories;

namespace WebApplication3.Implementation
{
    public class StadiumRepository:Genericrepository<Stadium>,IStadiumRepository

    {
        public StadiumRepository(ApplicationDbContext context):base(context)
        {
            
        }
    }
}
