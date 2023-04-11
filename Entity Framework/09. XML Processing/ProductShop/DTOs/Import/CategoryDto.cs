namespace ProductShop.DTOs.Import;

using System.Xml.Serialization;

[XmlType("Category")]
public class CategoryDto
{
    [XmlElement("name")] 
    public string Name { get; set; } = null!;
}