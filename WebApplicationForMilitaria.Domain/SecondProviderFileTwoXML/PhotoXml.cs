
using System.Xml.Serialization;

namespace WebApplicationForMilitaria.Domain.SecondProviderFileTwoXML
{
    public class PhotoXml
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("main")]
        public bool IsMain { get; set; }

        [XmlText]
        public string Url { get; set; }
    }
}
