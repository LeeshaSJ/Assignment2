using System.ComponentModel.DataAnnotations;
namespace Assignment2.Models
{
    public class Allocation
    {
        [Key]
        public string Id { get; set; }

        //public string? user_id { get; set; }

        [MaxLength(150)]
        [Display(Name = "Allocation Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateOnly? AllocationDate { get; set; }

        [MaxLength(150)]
        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateOnly? ReturnDate { get; set; }

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
