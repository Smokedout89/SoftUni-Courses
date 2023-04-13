namespace Artillery.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Common;
using Data.Models;

[XmlType(nameof(Manufacturer))]
public class ImportManufacturersDto
{
    [XmlElement(nameof(ManufacturerName))]
    [Required]
    [MinLength(ValidationConstants.ManufacturerNameMinLength)]
    [MaxLength(ValidationConstants.ManufacturerNameMaxLength)]
    public string ManufacturerName { get; set; } = null!;

    [XmlElement(nameof(Founded))]
    [Required]
    [MinLength(ValidationConstants.ManufacturerFoundedMinLength)]
    [MaxLength(ValidationConstants.ManufacturerFoundedMaxLength)]
    public string Founded { get; set; } = null!;
}