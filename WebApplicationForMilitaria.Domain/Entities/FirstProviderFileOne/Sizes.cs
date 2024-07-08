
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WebApplicationForMilitaria.Domain.Entities.FirstProviderFileOne
{
    public class Sizes
    {
        [Key]
        public int SizesId { get; set; }

        [XmlElement(ElementName = "size")]
        public List<Size> SizeList { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
