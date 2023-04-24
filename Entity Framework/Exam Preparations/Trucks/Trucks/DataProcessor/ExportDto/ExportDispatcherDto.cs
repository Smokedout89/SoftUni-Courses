namespace Trucks.DataProcessor.ExportDto;

using System.Xml.Serialization;

using Data.Models;

[XmlType(nameof(Despatcher))]
public class ExportDispatcherDto
{
    [XmlAttribute(nameof(TrucksCount))]
    public int TrucksCount { get; set; }

    [XmlElement(nameof(DespatcherName))]
    public string DespatcherName { get; set; } = null!;

    [XmlArray(nameof(Trucks))]
    public ExportTruckDto[] Trucks { get; set; } = null!;
}