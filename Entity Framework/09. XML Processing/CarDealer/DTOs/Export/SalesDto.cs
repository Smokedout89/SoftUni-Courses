namespace CarDealer.DTOs.Export;

using System.Xml.Serialization;

[XmlType("sale")]
public class SalesDto
{
    [XmlElement("car")]
    public SaleCarDto Car { get; set; } = null!;

    [XmlElement("discount")]
    public string Discount { get; set; } = null!;

    [XmlElement("customer-name")]
    public string CustomerName { get; set; } = null!;

    [XmlElement("price")]
    public double Price { get; set; }

    [XmlElement("price-with-discount")]
    public double PriceWithDiscount { get; set; }
}