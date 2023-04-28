using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Repositories;

namespace WebApplication3.Implementation
{
    public class TicketRepository:Genericrepository<Ticket>,ITicketRepository

    {
        public TicketRepository(ApplicationDbContext context):base(context)
        {
            
        }
    }
}
