using WebApplication3.Data;
using WebApplication3.Repositories;

namespace WebApplication3.Implementation
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)

        {
            this._context = context;
            Stadium=new StadiumRepository(context);
        }

        public IStadiumRepository Stadium { get;private set; }
        public IEnclosureRepository Enclosure { get;private set; }
        public ISeatRepository Seat { get;private set; }
        public IMatchRepository Match { get;private set; }  
        public ITicketRepository Ticket { get;private set; }

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
