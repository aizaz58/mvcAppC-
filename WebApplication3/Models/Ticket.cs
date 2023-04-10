using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public int? MatchId { get; set; }
        public Match Matches { get; set; }
        public int? SeatId { get; set; }  
        public Seat Seats { get; set; }
        


      
    }

}
