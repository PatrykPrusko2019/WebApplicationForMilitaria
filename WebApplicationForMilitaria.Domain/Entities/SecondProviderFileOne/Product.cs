
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace WebApplicationForMilitaria.Domain.Entities.SecondProviderFileOne
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("ean")]
        public string Ean { get; set; }


        [XmlElement("sku")]
        public string Sku { get; set; }

        [XmlElement("inStock")]
        public string InStock { get; set; }

        [XmlElement("qty")]
        public int Qty { get; set; }

        [XmlElement("availability")]
        public string Availability { get; set; }

        public int ProductIdFromXML { get; set; }

        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }

        public bool IsEditable { get; set; }
    }
}
