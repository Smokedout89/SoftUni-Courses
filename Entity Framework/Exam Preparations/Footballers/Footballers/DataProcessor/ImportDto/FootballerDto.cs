namespace Footballers.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Common;

[XmlType("Footballer")]
public class FootballerDto
{
    [Required]
    [XmlElement("Name")]
    [MinLength(ValidationConstants.FootballerNameMinLength)]
    [MaxLength(ValidationConstants.FootballerNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement("ContractStartDate")]
    public string ContractStartDate { get; set; } = null!;

    [Required]
    [XmlElement("ContractEndDate")]
    public string ContractEndDate { get; set; } = null!;

    [XmlElement("BestSkillType")]
    public int BestSkillType { get; set; }

    [XmlElement("PositionType")]
    public int PositionType { get; set; }
}