using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class StudentModel
    {
        [Key]
        public string? UserId { get; set; }

        [MaxLength(150)]
        [Display(Name = "Course ID")]
        [DataType(DataType.Text)]
        [Required]
        public string? CourseId { get; set; }

        public UserModel? User { get; set; }
    }
}
