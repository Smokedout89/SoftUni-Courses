namespace ProductShop.DTOs.Export;

using System.Xml.Serialization;

public class UserWithProducts
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("users")]
    public UserInfoWithProductsDto[] Users { get; set; }
}