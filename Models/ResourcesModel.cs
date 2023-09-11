using System.ComponentModel.DataAnnotations;
namespace Assignment2.Models
{
    public class ResourcesModel
    {
        [Key]
        public string? ResourceId { get; set; }

        [MaxLength(150)]
        [Display(Name = "Resource Type")]
        [DataType(DataType.Text)]
        [Required]
        public string? ResourceType { get; set; }

        [MaxLength(150)]
        [Display(Name = "Resource Name")]
        [DataType(DataType.Text)]
        [Required]
        public string? ResourceName { get; set; }

        [MaxLength(150)]
        [Display(Name = "Resource Description")]
        [DataType(DataType.Text)]
        [Required]
        public string? ResourceDescription { get; set; }

        [MaxLength(150)]
        [Display(Name = "Quantity")]
        [DataType(DataType.Text)]
        [Required]
        public int? Quantity { get; set; }

        [MaxLength(150)]
        [Display(Name = "Unit Id")]
        [DataType(DataType.Text)]
        [Required]
        public string? UnitId { get; set; }

        [MaxLength(150)]
        [Display(Name = "Image Path")]
        [DataType(DataType.Text)]
        [Required]
        public string? ImagePath { get; set; }

        [Display(Name = "Valuable")]
        public bool? IsValuable { get; set; }

        public RequestModel? Request { get; set; }
    }
}
