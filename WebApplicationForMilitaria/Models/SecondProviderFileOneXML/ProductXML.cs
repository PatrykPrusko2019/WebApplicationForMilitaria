using System.Xml.Serialization;

namespace WebApplicationForMilitaria.MVC.Models.SecondProviderFileOneXML
{
    [XmlRoot(ElementName = "product")]
    public class ProductXML
    {
        [XmlElement(ElementName = "ean")]
        public string EAN { get; set; }

        [XmlElement(ElementName = "id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "sku")]
        public string SKU { get; set; }

        [XmlElement(ElementName = "inStock")]
        public bool InStock { get; set; }

        [XmlElement(ElementName = "qty")]
        public int Quantity { get; set; }

        [XmlElement(ElementName = "availability")]
        public string Availability { get; set; }
    }

    [XmlRoot(ElementName = "products")]
    public class ProductsXML
    {
        [XmlAttribute(AttributeName = "elments")]
        public int Elements { get; set; }

        [XmlAttribute(AttributeName = "clientid")]
        public int ClientId { get; set; }

        [XmlAttribute(AttributeName = "lang")]
        public string Language { get; set; }

        [XmlAttribute(AttributeName = "datetime")]
        public DateTime DateTime { get; set; }

        [XmlElement(ElementName = "product")]
        public List<ProductXML> ProductList { get; set; }
    }
}
