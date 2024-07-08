
using System.Xml.Serialization;

namespace WebApplicationForMilitaria.Domain.SecondProviderFileTwoXML
{
    [XmlRoot("products")]
    public class ProductsXml
    {
        [XmlElement("product")]
        public List<ProductXml> ProductList { get; set; }
    }
}
