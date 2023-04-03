using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Stadium
    {
        [Key]
        public int StdID { get; set; }
        [Required]
        public string Std_Name { get; set; }
        public string Std_CityName { get; set; }
        public int Std_Capacity { get; set; }   
    }
}
