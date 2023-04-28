namespace WebApplication3.Repositories
{
    public interface IUnitOfWork:IDisposable
    {

        IStadiumRepository Stadium { get; }
        IEnclosureRepository Enclosure { get; }
        ISeatRepository Seat { get; }
        IMatchRepository Match { get; }
        ITicketRepository Ticket { get; }

        int Save();
    }
}
