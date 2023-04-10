using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication3.Models;

namespace WebApplication3.Models
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SeatNo { get; set; }

        [Required]
        public int SeatPrice { get; set; }

        
        public ICollection<Ticket> Ticket { get; set; }=new List<Ticket>();
        public int EnclosureId { get; set; }
        public Enclosure Enclosures { get; set; }
       



  
    }
}
