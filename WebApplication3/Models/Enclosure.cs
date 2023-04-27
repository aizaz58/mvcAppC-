using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication3.Models
{
    public class Enclosure
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [DisplayName("Enclosure Name")]
        public string Name { get; set; }


        [Required]
        [DisplayName("Price")]
        public int PricePerSeat { get; set; }


        //[NotMapped]
        //public Seat Seat { get; set; }


        [Required]
        [DisplayName("Capacity")]
        public int Capacity { get; set; }

        [DisplayName("Stadium")]


        public int StadiumId { get; set; }
        
        public Stadium Stadiums { get; set; }
   
        public ICollection<Seat> Seats { get; } 
        


    }
}
