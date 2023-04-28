using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Repositories;

namespace WebApplication3.Implementation
{
    public class EnclosureRepository:Genericrepository<Enclosure>, IEnclosureRepository
    {
        public EnclosureRepository(ApplicationDbContext context):base(context)
        {
            
        }
    }
}
