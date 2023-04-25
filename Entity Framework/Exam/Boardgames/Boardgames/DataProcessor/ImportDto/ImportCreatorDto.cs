namespace Boardgames.DataProcessor.ImportDto;

using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

using Common;
using Data.Models;

[XmlType(nameof(Creator))]
public class ImportCreatorDto
{
    [XmlElement(nameof(FirstName))]
    [Required]
    [MinLength(ValidationConstants.CreatorFirstNameMinLength)]
    [MaxLength(ValidationConstants.CreatorFirstNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [XmlElement(nameof(LastName))]
    [Required]
    [MinLength(ValidationConstants.CreatorLastNameMinLength)]
    [MaxLength(ValidationConstants.CreatorLastNameMaxLength)]
    public string LastName { get; set; } = null!;

    [XmlArray(nameof(Boardgames))]
    public ImportBoardgameDto[] Boardgames { get; set; } = null!;
}