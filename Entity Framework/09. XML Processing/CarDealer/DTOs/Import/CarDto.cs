namespace CarDealer.DTOs.Import;

using System.Xml.Serialization;

[XmlType("Car")]
public class CarDto
{
    [XmlElement("make")]
    public string Make { get; set; } = null!;

    [XmlElement("model")]
    public string Model { get; set; } = null!;

    [XmlElement("traveledDistance")]
    public long TraveledDistance { get; set; }

    [XmlArray("parts")] 
    public PartIdDto[] Parts { get; set; }
}