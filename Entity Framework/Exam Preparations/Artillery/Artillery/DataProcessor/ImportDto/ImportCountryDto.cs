namespace Artillery.DataProcessor.ImportDto;

using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

using Common;
using Data.Models;

[XmlType(nameof(Country))]
public class ImportCountryDto
{
    [XmlElement(nameof(CountryName))]
    [Required]
    [MinLength(ValidationConstants.CountryNameMinLength)]
    [MaxLength(ValidationConstants.CountryNameMaxLength)]
    public string CountryName { get; set; } = null!;

    [Range(ValidationConstants.CountryArmyMinSize, ValidationConstants.CountryArmyMaxSize)]
    public int ArmySize { get; set; }
}