namespace CarDealer.DTOs.Import;

using System.Xml.Serialization;

[XmlType("Supplier")]
public class SupplierDto
{
    [XmlElement("name")]
    public string Name { get; set; } = null!;

    [XmlElement("isImporter")]
    public bool IsImporter { get; set; }
}