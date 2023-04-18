namespace Footballers.DataProcessor.ExportDto;

using System.Xml.Serialization;

[XmlType("Footballer")]
public class ExportFootballersDto
{
    [XmlElement]
    public string Name { get; set; } = null!;

    [XmlElement]
    public string Position { get; set; } = null!;
}