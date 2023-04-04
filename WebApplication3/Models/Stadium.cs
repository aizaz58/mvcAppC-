using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Stadium
    {
        [Key]
        public int StdID { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="name can be max 50 char long ."),MinLength(10,ErrorMessage = "name can be  min 10 har short.")]
      
        [DisplayName("Stadium Name")]
        public string Std_Name { get; set; }
        [DisplayName("City Name")]
        public string Std_CityName { get; set; }
        [DisplayName("Stadium Capacity")]
        public int Std_Capacity { get; set; }   
    }
}
