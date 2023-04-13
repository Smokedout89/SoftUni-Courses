namespace Artillery.DataProcessor.ImportDto;

using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

using Common;

[XmlType("Shell")]
public class ImportShellDto
{
    [XmlElement(nameof(ShellWeight))]
    [Range(ValidationConstants.ShellWeightMinValue, ValidationConstants.ShellWeightMaxValue)]
    public double ShellWeight { get; set; }

    [XmlElement(nameof(Caliber))]
    [Required]
    [MinLength(ValidationConstants.ShellCaliberMinLength)]
    [MaxLength(ValidationConstants.ShellCaliberMaxLength)]
    public string Caliber { get; set; } = null!;
}