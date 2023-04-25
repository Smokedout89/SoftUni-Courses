namespace Boardgames.Common;

using System.Text;
using System.Xml.Serialization;

public class XmlHelper
{
    public T Deserialize<T>(string inputXml, string rootName)
    {
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

        using StringReader reader = new StringReader(inputXml);
        T dtos = (T)xmlSerializer
            .Deserialize(reader)!;

        return dtos;
    }

    public string Serialize<T>(T dto, string rootName)
    {
        StringBuilder sb = new StringBuilder();

        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);
        using StringWriter writer = new StringWriter(sb);
        xmlSerializer.Serialize(writer, dto, namespaces);

        return sb.ToString().TrimEnd();
    }
}