using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Repositories;

namespace WebApplication3.Implementation
{
    public class SeatRepository:Genericrepository<Seat>,ISeatRepository
    {
        public SeatRepository(ApplicationDbContext context):base(context)
        {

        }
       
    }
}
