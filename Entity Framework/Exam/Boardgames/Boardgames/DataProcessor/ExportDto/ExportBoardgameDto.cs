namespace Boardgames.DataProcessor.ExportDto;

using System.Xml.Serialization;

using Data.Models;

[XmlType(nameof(Boardgame))]
public class ExportBoardgameDto
{
    [XmlElement(nameof(BoardgameName))]
    public string BoardgameName { get; set; } = null!;

    [XmlElement(nameof(BoardgameYearPublished))]
    public int BoardgameYearPublished { get; set; }
}