using System.ComponentModel.DataAnnotations;
namespace Assignment2.Models
{
    public class UserModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string FirstLastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Department { get; set; }
    }
}
