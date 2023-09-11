using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class TeacherModel
    {
        [Key]
        public string? UserId { get; set; }

        [MaxLength(150)]
        [Display(Name = "Department")]
        [DataType(DataType.Text)]
        [Required]
        public string? Department { get; set; }

        [MaxLength(150)]
        [Display(Name = "Units")]
        [DataType(DataType.Text)]
        [Required]
        public string? Units { get; set; }

        public UserModel? User { get; set; }
    }
}
