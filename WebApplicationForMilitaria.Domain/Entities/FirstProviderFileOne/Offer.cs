
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WebApplicationForMilitaria.Domain.Entities.FirstProviderFileOne
{
    [XmlRoot(ElementName = "offer")]
    public class Offer
    {
        [Key]
        public int OfferId { get; set; }

        [XmlElement(ElementName = "products")]
        public Products Products { get; set; }
    }
}
