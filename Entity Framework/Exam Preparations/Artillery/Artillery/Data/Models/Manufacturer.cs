namespace Artillery.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Manufacturer
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.ManufacturerNameMaxLength)]
    public string ManufacturerName { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstants.ManufacturerFoundedMaxLength)]
    public string Founded { get; set; } = null!;

    public virtual ICollection<Gun> Guns { get; set; } = new HashSet<Gun>();
}