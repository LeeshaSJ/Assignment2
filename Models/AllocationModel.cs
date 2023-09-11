using System.ComponentModel.DataAnnotations;
namespace Assignment2.Models
{
    public class AllocationModel
    {
        [Key]
        public int AllocationId { get; set; }

        [MaxLength(150)]
        [Display(Name = "Allocation Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime? AllocationDate { get; set; }

        [MaxLength(150)]
        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime? ReturnDate { get; set; }

        [MaxLength(150)]
        [Display(Name = "Student ID")]
        [DataType(DataType.Text)]
        [Required]
        public string? StudentId { get; set; }

        [MaxLength(150)]
        [Display(Name = "Resource ID")]
        [DataType(DataType.Text)]
        [Required]
        public string? ResourceId { get; set; }

    }
}
