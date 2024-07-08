
using System.Xml.Serialization;
using WebApplicationForMilitaria.Domain.SecondProviderFileTwoXML;

namespace WebApplicationForMilitaria.Domain.ThirdProviderFileOneXML
{
    [XmlRoot("produkty")]
    public class ProductsXml
    {
        [XmlElement("produkt")]
        public List<ProductXml> ProductList { get; set; }
    }
}
