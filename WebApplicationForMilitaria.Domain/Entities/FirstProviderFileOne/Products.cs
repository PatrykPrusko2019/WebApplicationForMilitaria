
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WebApplicationForMilitaria.Domain.Entities.FirstProviderFileOne
{
    public class Products
    {
        [Key]
        public int ProductsId { get; set; }

        [XmlElement(ElementName = "product")]
        public List<Product> ProductList { get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; }
    }
}
