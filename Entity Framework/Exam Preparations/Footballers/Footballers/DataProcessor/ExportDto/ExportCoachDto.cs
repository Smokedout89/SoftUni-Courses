namespace Footballers.DataProcessor.ExportDto;

using System.Xml.Serialization;

[XmlType("Coach")]
public class ExportCoachDto
{
    [XmlAttribute("FootballersCount")]
    public string FootballersCount { get; set; } = null!;

    [XmlElement("CoachName")]
    public string CoachName { get; set; } = null!;

    [XmlArray("Footballers")]
    public ExportFootballersDto[] Footballers { get; set; }
}