
using System.Xml.Serialization;

namespace WebApplicationForMilitaria.Domain.SecondProviderFileTwoXML
{
    public class ProductXml
    {
        [XmlElement("ean")]
        public string Ean { get; set; }

        [XmlElement("sku")]
        public string Sku { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("desc")]
        public string Desc { get; set; }

        [XmlElement("url")]
        public string Url { get; set; }

        [XmlElement("unit")]
        public string Unit { get; set; }

        [XmlElement("weight")]
        public string Weight { get; set; }

        [XmlElement("PKWiU")]
        public string PKWiU { get; set; }

        [XmlElement("inStock")]
        public string InStock { get; set; }

        [XmlElement("qty")]
        public int Qty { get; set; }

        [XmlElement("requiredBox")]
        public string RequiredBox { get; set; }

        [XmlElement("quantityPerBox")]
        public int QuantityPerBox { get; set; }

        [XmlElement("priceAfterDiscountNet")]
        public string PriceAfterDiscountNet { get; set; }

        [XmlElement("vat")]
        public int Vat { get; set; }

        [XmlElement("retailPriceGross")]
        public decimal RetailPriceGross { get; set; }

        [XmlArray("categories")]
        [XmlArrayItem("category")]
        public List<CategoryXml> Categories { get; set; }

        [XmlArray("photos")]
        [XmlArrayItem("photo")]
        public List<PhotoXml> Photos { get; set; }
    }
}
