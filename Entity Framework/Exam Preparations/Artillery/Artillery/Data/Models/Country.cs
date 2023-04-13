namespace Artillery.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Country
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.CountryNameMaxLength)]
    public string CountryName { get; set; } = null!;

    public int ArmySize { get; set; }

    public virtual ICollection<CountryGun> CountriesGuns { get; set; } = new HashSet<CountryGun>();
}