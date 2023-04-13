namespace Artillery.DataProcessor.ExportDto;

using System.Xml.Serialization;

using Data.Models;

[XmlType(nameof(Gun))]
public class ExportGunDto
{
    [XmlAttribute(nameof(Manufacturer))]
    public string Manufacturer { get; set; } = null!;

    [XmlAttribute(nameof(GunType))]
    public string GunType { get; set; } = null!;

    [XmlAttribute(nameof(GunWeight))]
    public int GunWeight { get; set; }

    [XmlAttribute(nameof(BarrelLength))]
    public double BarrelLength { get; set; }

    [XmlAttribute(nameof(Range))]
    public int Range { get; set; }

    [XmlArray(nameof(Countries))]
    public ExportCountryDto[] Countries { get; set; } = null!;
}