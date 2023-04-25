namespace Boardgames.DataProcessor.ImportDto;

using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

using Common;
using Data.Models;

[XmlType(nameof(Boardgame))]
public class ImportBoardgameDto
{
    [XmlElement(nameof(Name))]
    [Required]
    [MinLength(ValidationConstants.BoardgameNameMinLength)]
    [MaxLength(ValidationConstants.BoardgameNameMaxLength)]
    public string Name { get; set; } = null!;

    [XmlElement(nameof(Rating))]
    [Range(ValidationConstants.BoardgameRatingMinValue, ValidationConstants.BoardgameRatingMaxValue)]
    public double Rating { get; set; }

    [XmlElement(nameof(YearPublished))]
    [Range(ValidationConstants.BoardgameYearPublishedMinValue, ValidationConstants.BoardgameYearPublishedMaxValue)]
    public int YearPublished { get; set; }

    [XmlElement(nameof(CategoryType))]
    public int CategoryType { get; set; }

    [XmlElement(nameof(Mechanics))]
    [Required]
    public string Mechanics { get; set; } = null!;
}