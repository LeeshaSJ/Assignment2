using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2.Models
{
    public class RequestModel
    {
        [Key]
        [MaxLength(150)]
        [Display(Name = "Request Id")]
        [DataType(DataType.Text)]
        [Required]
        public string? RequestId { get; set; }

        [MaxLength(150)] 
        [Display(Name = "Student Id")]
        [DataType(DataType.Text)]
        [Required]
        public string? StudentId { get; set; }

        [MaxLength(150)]
        [Display(Name = "Resource Id")]
        [DataType(DataType.Text)]
        [Required]
        public string? ResourceId { get; set; }

        [MaxLength(150)]
        [Display(Name = "Unit Id")]
        [DataType(DataType.Text)]
        [Required]
        public string? UnitId { get; set; }

        public ResourcesModel? Resource { get; set; }

    }
}
