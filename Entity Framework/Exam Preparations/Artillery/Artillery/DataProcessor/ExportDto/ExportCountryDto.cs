namespace Artillery.DataProcessor.ExportDto;

using System.Xml.Serialization;

[XmlType(nameof(Country))]
public class ExportCountryDto
{
    [XmlAttribute(nameof(Country))]
    public string Country { get; set; } = null!;

    [XmlAttribute(nameof(ArmySize))]
    public int ArmySize { get; set; }
}