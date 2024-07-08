
using System.Xml.Serialization;

namespace WebApplicationForMilitaria.Domain.ThirdProviderFileOneXML
{
    public class ProductXml
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("nazwa")]
        public string Name { get; set; }

        [XmlElement("nazwa_pl")]
        public string NamePl { get; set; }

        [XmlElement("nazwa_en")]
        public string NameEn { get; set; }

        [XmlElement("dlugi_opis")]
        public string Description { get; set; }

        [XmlElement("dlugi_opis_pl")]
        public string DescriptionPl { get; set; }

        [XmlElement("dlugi_opis_en")]
        public string DescriptionEn { get; set; }

        [XmlElement("kod")]
        public string Code { get; set; }

        [XmlElement("ean")]
        public string Ean { get; set; }

        [XmlElement("status")]
        public int Status { get; set; }

        [XmlElement("cena_zewnetrzna_hurt")]
        public decimal WholesalePrice { get; set; }

        [XmlElement("cena_sugerowana")]
        public decimal SuggestedPrice { get; set; }

        [XmlElement("kod_dostawcy")]
        public string SupplierCode { get; set; }

        [XmlElement("vat")]
        public decimal Vat { get; set; }

        [XmlElement("rozmiar")]
        public string Size { get; set; }

        [XmlElement("kolor")]
        public string Color { get; set; }

        [XmlElement("cat")]
        public string Category { get; set; }

        [XmlElement("cat_pl")]
        public string CategoryPl { get; set; }

        [XmlElement("cat_en")]
        public string CategoryEn { get; set; }

        [XmlArray("zdjecia")]
        [XmlArrayItem("zdjecie")]
        public List<PhotoXml> Photos { get; set; }
    }
}
