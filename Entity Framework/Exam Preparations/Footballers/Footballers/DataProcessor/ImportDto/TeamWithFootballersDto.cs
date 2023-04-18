namespace Footballers.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

using Common;

public class TeamWithFootballersDto
{
    [Required]
    [RegularExpression(@"^[a-zA-Z0-9\s\.\-]+$")]
    [MinLength(ValidationConstants.TeamNameMinLength)]
    [MaxLength(ValidationConstants.TeamNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required(AllowEmptyStrings = false)]
    [MinLength(ValidationConstants.TeamNationalityMinLength)]
    [MaxLength(ValidationConstants.TeamNationalityMaxLength)]
    public string Nationality { get; set; } = null!;

    [Required(AllowEmptyStrings = false)]
    public string Trophies { get; set; } = null!;

    public int[]? Footballers { get; set; }
}