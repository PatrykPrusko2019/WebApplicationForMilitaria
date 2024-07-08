
using System.Xml.Serialization;
namespace WebApplicationForMilitaria.Domain.Entities.SecondProviderFileOne
{
    [XmlRoot("products")]
    public class Products
    {
        [XmlElement("product")]
        public Product[] ProductList { get; set; }

    }
}
