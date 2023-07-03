using System.ComponentModel.DataAnnotations;

namespace GymApi.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
     
    }
}
