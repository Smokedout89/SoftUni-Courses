namespace Trucks.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

using Common;

public class ClientDto
{
    [Required]
    [MinLength(ValidationConstants.ClientNameMinLength)]
    [MaxLength(ValidationConstants.ClientNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MinLength(ValidationConstants.ClientNationalityMinLength)]
    [MaxLength(ValidationConstants.ClientNationalityMaxLength)]
    public string Nationality { get; set; } = null!;

    [Required]
    public string Type { get; set; } = null!;

    public int[] Trucks { get; set; } = null!;
}