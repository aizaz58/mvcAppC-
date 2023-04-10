using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebApplication3.Models;


namespace WebApplication3.Data
{
    public class ApplicationDbContext:DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
           
        }

        public DbSet<Stadium> Stadiums { get; set;}
        public DbSet<Enclosure> Enclosures { get; set;}
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Match> Matches { get; set; }
       
    }




}
