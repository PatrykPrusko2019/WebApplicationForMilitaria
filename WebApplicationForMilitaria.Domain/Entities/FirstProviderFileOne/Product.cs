
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WebApplicationForMilitaria.Domain.Entities.FirstProviderFileOne
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "price")]
        public Price Price { get; set; }

        [XmlElement(ElementName = "srp")]
        public Srp Srp { get; set; }

        [XmlElement(ElementName = "sizes")]
        public Sizes Sizes { get; set; }

        public int ProductsId { get; set; }
        public Products Products { get; set; }

        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }

        public bool IsEditable { get; set; }
    }
}
