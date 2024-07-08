
using System.ComponentModel.DataAnnotations;

namespace WebApplicationForMilitaria.Domain.Entities.FirstProviderFileTwo
{
    public class Size
    {
        [Key]
        public int Id { get; set; }
        public string CodeProducer { get; set; }
        public string Code { get; set; }
        public decimal PriceNet { get; set; }
        public decimal PriceGross { get; set; }
        public decimal SrvNet { get; set; }
        public decimal SrvGross { get; set; }
        public int StockId { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
