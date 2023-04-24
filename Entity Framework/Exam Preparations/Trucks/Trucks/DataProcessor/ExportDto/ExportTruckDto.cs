namespace Trucks.DataProcessor.ExportDto;

using System.Xml.Serialization;

using Data.Models;

[XmlType(nameof(Truck))]
public class ExportTruckDto
{
    [XmlElement(nameof(RegistrationNumber))]
    public string RegistrationNumber { get; set; } = null!;

    [XmlElement(nameof(Make))] 
    public string Make { get; set; } = null!;
}