using System.ComponentModel.DataAnnotations;
namespace Assignment2.Models
{
    public class UserModel
    {
        [Key]
        public string? Id { get; set; }

        [MaxLength(150)]
        [Display(Name = "Full Name")]
        [DataType(DataType.Text)]
        [Required]
        public string? FullName { get; set; }

        [MaxLength(150)]
        [Display(Name = "Email")]
        [DataType(DataType.Text)]
        [Required]
        public string? Email { get; set; }

        [MaxLength(150)]
        [Display(Name = "Department")]
        [DataType(DataType.Text)]
        [Required]
        public string? Department { get; set; }
    }
}
