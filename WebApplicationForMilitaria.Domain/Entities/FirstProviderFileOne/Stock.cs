
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WebApplicationForMilitaria.Domain.Entities.FirstProviderFileOne
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "quantity")]
        public int Quantity { get; set; }

        public int SizeId { get; set; }
        public Size Size { get; set; }
    }
}
