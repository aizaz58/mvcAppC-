using WebApplication3.Data;
using WebApplication3.Services;
using WebApplication3.Interfaces;
using WebApplication3.Repositories;

namespace WebApplication3.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
      

        public IEnclosureRepository Enclosure { get; private set; }

        public ISeatRepository Seat { get; private set; }

        public IMatchRepository Match { get; private set; }

        public ITicketRepository Ticket { get; private set; }
        public IStadiumRepository Stadium{ get;private set; }


        public UnitOfWork(ApplicationDbContext context,IEnclosureRepository enclosureRepository
            ,ISeatRepository seatRepository,IStadiumRepository stadiumRepository,IMatchRepository matchRepository,
            ITicketRepository ticketRepository)

        {
            _context = context;
            this.Enclosure = enclosureRepository;
            this.Seat = seatRepository;
            this.Stadium = stadiumRepository;
            this.Match = matchRepository;
            this.Ticket = ticketRepository;
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