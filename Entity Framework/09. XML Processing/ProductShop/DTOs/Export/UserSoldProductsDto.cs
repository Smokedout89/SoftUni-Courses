namespace ProductShop.DTOs.Export;

using System.Xml.Serialization;

[XmlType("SoldProducts")]
public class UserSoldProductsDto
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("products")]
    public SoldProductsDto[] Products { get; set; }
}