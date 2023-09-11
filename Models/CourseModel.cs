using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class CourseModel
    {
        [Key]
        [MaxLength(150)]
        [Display(Name = "Course Id")]
        [DataType(DataType.Text)]
        [Required]
        public string? CourseId { get; set; }

        [MaxLength(150)]
        [Display(Name = "Course Name")]
        [DataType(DataType.Text)]
        [Required]
        public string? CourseName { get; set; }
    }
}
