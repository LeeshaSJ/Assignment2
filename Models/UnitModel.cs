using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class UnitModel
    {
        [Key]
        [MaxLength(150)]
        [Display(Name = "Unit Id")]
        [DataType(DataType.Text)]
        [Required]
        public string? UnitId { get; set; }

        [MaxLength(150)]
        [Display(Name = "Unit Name")]
        [DataType(DataType.Text)]
        [Required]
        public string? UnitName { get; set; }
    }
}
