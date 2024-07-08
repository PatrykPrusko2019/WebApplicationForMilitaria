
using System.ComponentModel.DataAnnotations;

namespace WebApplicationForMilitaria.Domain.FirstProviderFileTwoXML
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProducerId { get; set; }
        public string CategoryId { get; set; }
        public string UnitId { get; set; }
        public string WarrantyId { get; set; }
        public string CardUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceNet { get; set; }
        public decimal PriceGross { get; set; }
        public decimal SrvNet { get; set; }
        public decimal SrvGross { get; set; }
        public List<Image> Images { get; set; }
        public List<Icon> Icons { get; set; }
        public List<Size> Sizes { get; set; }
        public List<Parameter> Parameters { get; set; }

    }
}
