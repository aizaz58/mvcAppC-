using WebApplication3.Data;
using WebApplication3.Implementation;
using WebApplication3.Repositories;

namespace WebApplication3.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IStadiumRepository Stadium { get; private set; }
        public IEnclosureRepository Enclosure { get; private set; }
        public ISeatRepository Seat { get; private set; }
        public IMatchRepository Match { get; private set; }
        public ITicketRepository Ticket { get; private set; }
        public UnitOfWork(ApplicationDbContext context)

        {
            _context = context;

            Stadium = new StadiumRepository(context);
            Enclosure = new EnclosureRepository(context);
            Seat = new SeatRepository(context);
            Match = new MatchRepository(context);
            Ticket = new TicketRepository(context);
        }



        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}