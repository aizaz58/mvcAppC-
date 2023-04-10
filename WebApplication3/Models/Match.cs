using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication3.Models;

namespace WebApplication3.Models
{
    public class Match
    {
        [Key]
        public int Id { get; set; }

        public string MatchName { get; set; }

        public DateTime MatchTime { get; set; }

        
        public ICollection<Ticket> Ticket { get; set; }=new List<Ticket>();

        public int StadiumId { get; set; }
        public Stadium Stadiums { get; set; }
        
      

    }
}
