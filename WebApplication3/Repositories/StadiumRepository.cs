using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Interfaces;

namespace WebApplication3.Repositories;

public class StadiumRepository:Genericrepository<Stadium>,IStadiumRepository

{
    public StadiumRepository(ApplicationDbContext context):base(context)
    {
        
    }
}
