using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication3.Models;

namespace WebApplication3.Models
{
    public class Stadium
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="name can be max 50 char long ."),MinLength(10,ErrorMessage = "name can be  min 10 har short.")]
      
        [DisplayName("Stadium Name")]
        public string Std_Name { get; set; }
        [DisplayName("City Name")]
        public string Std_CityName { get; set; }
        [DisplayName("Stadium Capacity")]
        public int Std_Capacity { get; set; }
        
        public ICollection<Enclosure> Enclosures { get; set; } 
        public ICollection<Match> Matches { get; set; }
       
        
    }
}
