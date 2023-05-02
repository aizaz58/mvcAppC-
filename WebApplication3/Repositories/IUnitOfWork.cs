using WebApplication3.Implementation;
using WebApplication3.Models;

namespace WebApplication3.Repositories
{
    public interface IUnitOfWork:IDisposable
    {

        /*StadiumRepository Stadium { get; }*/
        /*IEnclosureRepository Enclosure { get; }
        ISeatRepository Seat { get; }
        IMatchRepository Match { get; }
        ITicketRepository Ticket { get; }*/
        

        IGenericRepository<Stadium> Stadium { get; }  
        IGenericRepository<Enclosure> Enclosure { get; }  
        IGenericRepository<Seat> SeatRepository { get; }  
        IGenericRepository<Match> MatchRepository { get; }  
        IGenericRepository<Ticket> TicketRepository { get; }  
        
        int Save();
        
    }
}
