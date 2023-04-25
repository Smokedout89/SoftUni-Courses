namespace Boardgames.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

using Common;

public class ImportSellerDto
{
    [Required]
    [MinLength(ValidationConstants.SellerNameMinLength)]
    [MaxLength(ValidationConstants.SellerNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MinLength(ValidationConstants.SellerAddressMinLength)]
    [MaxLength(ValidationConstants.SellerAddressMaxLength)]
    public string Address { get; set; } = null!;

    [Required]
    public string Country { get; set; } = null!;

    [Required]
    [RegularExpression(ValidationConstants.SellerWebsiteRegex)]
    public string Website { get; set; } = null!;

    public int[] Boardgames { get; set; } = null!;
}