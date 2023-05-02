using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Repositories;

namespace WebApplication3.Implementation
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private readonly IGenericRepository<Stadium> _statiumRepo;
        private readonly IGenericRepository<Enclosure> _enclouseRepo;
        private readonly IGenericRepository<Seat> _seatRepo;
        private readonly IGenericRepository<Match> _matchRepo;
        private readonly IGenericRepository<Ticket> _TicketRepo;

        public UnitOfWork(
            
            ApplicationDbContext context,
            IGenericRepository<Stadium> statiumRepo,
            IGenericRepository<Enclosure> ep,
            IGenericRepository<Seat> sp,
            IGenericRepository<Match> mp,
            IGenericRepository<Ticket> tp
            )

        {
            _context = context;
            _statiumRepo = statiumRepo;
            _enclouseRepo = ep;
            _seatRepo = sp;
            _matchRepo = mp;
            _TicketRepo = tp;
        }

        public IGenericRepository<Stadium> StadiumRepository => _statiumRepo;

        public IGenericRepository<Enclosure> EnclosureRepository => _enclouseRepo;

        public IGenericRepository<Seat> SeatRepository => _seatRepo;

        public IGenericRepository<Match> MatchRepository => _matchRepo;

        public IGenericRepository<Ticket> TicketRepository => _TicketRepo;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }
    }

       

        
    }
}
