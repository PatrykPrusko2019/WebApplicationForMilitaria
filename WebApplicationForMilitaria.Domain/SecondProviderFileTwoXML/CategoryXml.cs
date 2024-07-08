
using System.Xml.Serialization;

namespace WebApplicationForMilitaria.Domain.SecondProviderFileTwoXML
{
    public class CategoryXml
    {
        [XmlAttribute("id")]
        public string CategoryIdXML { get; set; }

        [XmlText]
        public string Name { get; set; }
    }
}
