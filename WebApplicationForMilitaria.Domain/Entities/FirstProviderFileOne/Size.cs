
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WebApplicationForMilitaria.Domain.Entities.FirstProviderFileOne
{
    public class Size
    {
        [Key]
        public int SizeId { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "weight")]
        public decimal Weight { get; set; }

        [XmlAttribute(AttributeName = "code")]
        public string? Code { get; set; }

        [XmlAttribute(AttributeName = "code_producer")]
        public string? CodeProducer { get; set; } 

        [XmlElement(ElementName = "stock")]
        public Stock Stock { get; set; } 

        public int SizesId { get; set; }
        public Sizes Sizes { get; set; }
    }
}
