namespace Boardgames.DataProcessor.ExportDto;

using System.Xml.Serialization;

using Data.Models;

[XmlType(nameof(Creator))]
public class ExportCreatorDto
{
    [XmlAttribute(nameof(BoardgamesCount))]
    public int BoardgamesCount { get; set; }

    [XmlElement(nameof(CreatorName))]
    public string CreatorName { get; set; } = null!;

    [XmlArray(nameof(Boardgames))]
    public ExportBoardgameDto[] Boardgames { get; set; } = null!;
}