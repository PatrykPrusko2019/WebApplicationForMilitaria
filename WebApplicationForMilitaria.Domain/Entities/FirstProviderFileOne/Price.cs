
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WebApplicationForMilitaria.Domain.Entities.FirstProviderFileOne
{
    public class Price
    {
        [Key]
        public int PriceId { get; set; }

        [XmlAttribute(AttributeName = "vat")]
        public decimal Vat { get; set; }

        [XmlAttribute(AttributeName = "net")]
        public decimal Net { get; set; }

        [XmlAttribute(AttributeName = "gross")]
        public decimal Gross { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
