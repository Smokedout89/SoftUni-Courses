namespace Artillery.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

using Common;

public class ImportGunDto
{
    public int ManufacturerId { get; set; }

    [Range(ValidationConstants.GunWeightMinValue, ValidationConstants.GunWeightMaxValue)]
    public int GunWeight { get; set; }

    [Range(ValidationConstants.GunBarrelMinLength, ValidationConstants.GunBarrelMaxLength)]
    public double BarrelLength { get; set; }

    public int? NumberBuild { get; set; }

    [Range(ValidationConstants.GunRangeMinValue, ValidationConstants.GunRangeMaxValue)]
    public int Range { get; set; }

    [Required]
    public string GunType { get; set; } = null!;

    public int ShellId { get; set; }

    public ImportCountryId[] Countries { get; set; } = null!;
}