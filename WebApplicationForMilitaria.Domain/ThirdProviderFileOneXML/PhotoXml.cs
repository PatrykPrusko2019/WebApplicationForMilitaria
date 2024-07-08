
using System.Xml.Serialization;

namespace WebApplicationForMilitaria.Domain.ThirdProviderFileOneXML
{
    public class PhotoXml
    {
        [XmlAttribute("url")]
        public string Url { get; set; }
    }
}
